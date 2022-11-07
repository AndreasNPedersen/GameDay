using GameDay.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameDay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        GameContext _gameContext;
        public GroupsController(GameContext context)
        {
            _gameContext = context;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<GroupOwner> Get()
        {
         List<GroupOwner> groups = _gameContext.GroupOwner.Include(x=>x.userOwner).Include(x=>x.group).Include(x=>x.group.Game).Where(x=>x.group.Date >= DateTime.Now).ToList();
            for (int i = 0; i < groups.Count; i++)
            {
                groups[i].userOwner.password = "";
                groups[i].userOwner.UserId = 0;
                groups[i].userOwner.Created = default;
            }
            return groups;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public GroupOwner Get(int id)
        {
            GroupOwner groups = _gameContext.GroupOwner.Include(x => x.userOwner).Include(x => x.group).Include(x => x.group.Game).Where(x => x.group.GroupId == id).FirstOrDefault();
        
                groups.userOwner.password = "";
                groups.userOwner.UserId = 0;
                groups.userOwner.Created = default;

            return groups;
        }
        [HttpGet("GetGroupAttendees")]
        public List<GroupAttendees> GetGroupAttendees(int GroupId)
        {
            return _gameContext.GroupAttendees.Include(x => x.Group).Include(x => x.UserAttendeen).Include(x => x.Group.Game).Where(x => x.Group.GroupId == GroupId).ToList();
        }

        [HttpGet("Attendees")]
        public List<GroupAttendees> GetUserGroupsAttendees (int id)
        {
            var a = _gameContext.GroupAttendees.Include(x=>x.Group).Include(x=>x.UserAttendeen).Include(x=>x.Group.Game).Where(x => x.UserAttendeen.UserId == id).ToList();
            return a;

        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] GroupOwner value)
        {
            if (value != null && value.group.Name.Length >0 && value.group.Date > DateTime.Now)
            {
               _gameContext.Groups.Attach(value.group);
                var user = _gameContext.UserData.Where(x => x.UserId == value.userOwner.UserId).FirstOrDefault();
                GroupOwner data = new GroupOwner()
                {
                    group = value.group,
                    userOwner = user
                };

                _gameContext.GroupOwner.Attach(data);
                _gameContext.SaveChanges();
            }
        }

        [HttpPost("Join")]
        public void PostJoin([FromBody] GroupAttendeesDto attendeesDto)
        {
            if (attendeesDto.UserId > 0 && attendeesDto.GroupId > 0)
            {
                var user = _gameContext.UserData.Where(x => x.UserId == attendeesDto.UserId).FirstOrDefault();
                GroupAttendees attendeen = new GroupAttendees { 
                    UserAttendeen = user, Group = _gameContext.Groups.Where(x => x.GroupId == attendeesDto.GroupId).FirstOrDefault() 
                };
                _gameContext.GroupAttendees.Attach(attendeen);
                _gameContext.SaveChanges();
            }
        }


        // PUT api/<ValuesController>/5
        [HttpPost("UnJoin")]
        public void PostUnJoin([FromBody]GroupAttendeesDto attendeesDto)
        {
            if (attendeesDto.UserId > 0 && attendeesDto.GroupId > 0)
            {

                _gameContext.GroupAttendees.Remove(_gameContext.GroupAttendees.Include(x => x.Group).Include(x => x.UserAttendeen)
                    .Where(x => x.Group.GroupId == attendeesDto.GroupId && x.UserAttendeen.UserId == attendeesDto.UserId).FirstOrDefault());
              
                _gameContext.SaveChanges();
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _gameContext.Remove(_gameContext.Groups.Where(x => x.GroupId == id).FirstOrDefault());
            _gameContext.SaveChanges();
        }
    }
}

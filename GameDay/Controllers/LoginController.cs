using GameDay.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameDay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        GameContext _context;
        public LoginController(GameContext context)
        {
            _context = context;
        }


        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpPost("Login")]
        public ActionResult<UserLoginDto> PostLogin([FromBody] UserLoginDto user)
        {
            if (user != null && user.Name.Length > 0 & user.password.Length > 0)
            {
                var tryUser = _context.UserData.Where(x => x.Name == user.Name && x.password == user.password).FirstOrDefault();
                if (tryUser != null)
                {
                    tryUser.password = "";
                    return Ok(tryUser);
                }
                else
                {
                    return BadRequest("Wrong user login");
                }
            }
            return BadRequest("Wrong user login");
        }

        // POST api/<LoginController>
        [HttpPost("Create")]
        public IActionResult Postcreate([FromBody] UserData user)
        {
            if (user != null && user.Name.Length > 0 && user.password.Length > 0)
            {
                var tryUser = _context.UserData.Where(x => x.Name == user.Name).FirstOrDefault();
                if (tryUser == null)
                {
                    _context.UserData.Add(user);
                    _context.SaveChanges();
                    return Ok();
                }
            }
            return BadRequest();
        }

        // PUT api/<LoginController>/5
        [HttpPut]
        public void Put([FromBody] UserData value)
        {
            _context.UserData.Update(value);
            _context.SaveChanges();
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = _context.UserData.Where(x => x.UserId == id).FirstOrDefault();
            if ( user != null)
            {
                _context.UserData.Remove(user);
                _context.SaveChanges();
            }
     
        }
    }
}

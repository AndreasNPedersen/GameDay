using GameDay.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameDay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        GameContext _context;

        public GamesController(GameContext context)
        {
            _context = context;
        }

        // GET: api/<GamesController>
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return _context.Games.ToList();
        }

        // GET api/<GamesController>/5
        [HttpGet("{id}")]
        public ActionResult<Game> Get(int id)
        {
            if (id > 0)
                return Ok(_context.Games.Where(x => x.GameId == id).FirstOrDefault());
            else 
                return NotFound();
        }

        // POST api/<GamesController>
        [HttpPost]
        public void Post([FromBody] Game value)
        {
            if (value != null && !String.IsNullOrEmpty(value.Name))
            {
                _context.Games.Add(value);
                _context.SaveChanges();
            }
        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id >= 0 )
            {
            Game game = _context.Games.FirstOrDefault(x => x.GameId == id);
                if (game != null)
                {
                    _context.Games.Remove(game);
                    _context.SaveChanges();
                }
            }
        }
    }
}

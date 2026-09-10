using Microsoft.AspNetCore.Mvc;
using WebApiPractice.Models;

namespace WebApiPractice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private static readonly List<Game> games = new()
        {
            new Game { Id = 1, Title = "The Witcher 3", Genre = "RPG", Price = 1999.99m },
            new Game { Id = 2, Title = "FIFA 24", Genre = "Sports", Price = 2999.99m }
        };

        // GET /api/games
        [HttpGet]
        public ActionResult<List<Game>> GetAll()
        {
            return Ok(games);
        }

        // GET /api/games/{id}
        [HttpGet("{id}")]
        public ActionResult<Game> GetById(int id)
        {
            var game = games.FirstOrDefault(x => x.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        // POST /api/games
        [HttpPost]
        public ActionResult<Game> Create(Game game)
        {
            game.Id = games.Count == 0 ? 1 : games.Max(g => g.Id) + 1;
            games.Add(game);
            return CreatedAtAction(nameof(GetById), new { id = game.Id }, game);
        }

        // PUT /api/games/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Game updatedGame)
        {
            var game = games.FirstOrDefault(x => x.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            game.Title = updatedGame.Title;
            game.Genre = updatedGame.Genre;
            game.Price = updatedGame.Price;
            return NoContent();
        }

        // DELETE /api/games/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var game = games.FirstOrDefault(x => x.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            games.Remove(game);
            return NoContent();
        }
    }
}
using atividade_WebAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace atividade_WebAPI.Controllers
{
    public class PlayerController : ControllerBase
    {
        public static List<Player> players = new List<Player>() {
            { new Player { id = "1", Vida = 3, QuantidadeItens = 0, PosicaoX = 0f, PosicaoY = 0f, PosicaoZ = 0f } },
            { new Player { id = "2", Vida = 2, QuantidadeItens = 1, PosicaoX = 3.5f, PosicaoY = 1.2f, PosicaoZ = 2f } }
        };

        [HttpGet]
        [Route("Player")]
        public IActionResult GetPlayers()
        {
            return Ok(players);
        }

        [HttpGet]
        [Route("Player/{id}")]
        public IActionResult GetPlayerByID(string id)
        {
            var player = players.FirstOrDefault(a => a.id == id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        [HttpPost]
        [Route("Player")]
        public IActionResult AddPlayer([FromBody] Player newPlayer)
        {
            players.Add(newPlayer);
            return Ok(newPlayer);
        }

        [HttpPut]
        [Route("Player/{id}")]
        public IActionResult UpdatePlayer(string id, [FromBody] Player playerUpdated)
        {
            var player = players.FirstOrDefault(a => a.id == id);
            if (player == null)
            {
                return NotFound();
            }
            player.Vida = playerUpdated.Vida;
            player.QuantidadeItens = playerUpdated.QuantidadeItens;
            player.PosicaoX = playerUpdated.PosicaoX;
            player.PosicaoY = playerUpdated.PosicaoY;
            player.PosicaoZ = playerUpdated.PosicaoZ;
            return Ok(player);
        }

        [HttpDelete]
        [Route("Player/{id}")]
        public IActionResult DeletePlayer(string id)
        {
            var player = players.FirstOrDefault(a => a.id == id);
            if (player == null)
            {
                return NotFound();
            }
            players.Remove(player);
            return Ok();
        }
    }
}

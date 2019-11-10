using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamCRUDTestWebAPI.Contracts;
using TeamCRUDTestWebAPI.Models;

namespace TeamCRUDTestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> PostPlayer([FromBody] Players player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _playerRepository.Add(player);

            return Ok("created_id");
        }

        [HttpGet]
        public IActionResult GetPlayers()
        {
            return new ObjectResult(_playerRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = await _playerRepository.GetItem(id);
            if(player == null)
            {
                return NotFound();
            }

            return Ok("Success");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> deletePlayer([FromRoute] string id)
        {
            await _playerRepository.Remove(id);
            return Ok("Success");
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> PutPlayer([FromBody] Players player)
        {
            await _playerRepository.Update(player);
            return Ok("Success");
        }
    }
}
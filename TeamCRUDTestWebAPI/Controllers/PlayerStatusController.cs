using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamCRUDTestWebAPI.Contracts;
using TeamCRUDTestWebAPI.Models;

namespace TeamCRUDTestWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerStatusController : ControllerBase
    {
        private readonly IPlayerStatusRepository _playerStatusRepository;
        public PlayerStatusController(IPlayerStatusRepository playerStatusRepository)
        {
            _playerStatusRepository = playerStatusRepository;
        }

        [HttpGet]
        public IActionResult GetPlayerStatus()
        {
            return new ObjectResult(_playerStatusRepository.GettAllItms());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerStatus([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playerStatus = await _playerStatusRepository.Find(id);

            if (playerStatus == null)
            {
                return NotFound();
            }
            return Ok(playerStatus);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> PostPlayerStatus([FromBody] PlayerStatuses playerStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _playerStatusRepository.Add(playerStatus);

            return Content("created_id");

        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> PutPlayerStatus([FromBody]PlayerStatuses playerStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _playerStatusRepository.Update(playerStatus);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Something wrong");
            }

            return Ok("Success");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> deletePlayerStatus([FromRoute] int id)
        {
            try
            {
                await _playerStatusRepository.Remove(id);
            }
            catch
            {
                return StatusCode(404, "Not Found Item");
            }

            return Ok("Success");
        }

    }
}
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
    public class TeamStateController : ControllerBase
    {
        private readonly ITeamStateRepository _teamStateRepository;
        public TeamStateController(ITeamStateRepository teamStateRepository)
        {
            _teamStateRepository = teamStateRepository;
        }

        [HttpGet]
        public IActionResult GetTeamStates()
        {
            return new ObjectResult(_teamStateRepository.GettAllItms());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamState([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teamState = await _teamStateRepository.Find(id);

            if (teamState == null)
            {
                return NotFound();
            }
            return Ok(teamState);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> PostTeamState([FromBody] TeamStates teamState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _teamStateRepository.Add(teamState);

            return Content("created_id");

        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> PutTeamState([FromBody]TeamStates teamState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _teamStateRepository.Update(teamState);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Something wrong");
            }

            return Ok("Success");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> deleteTeamState([FromRoute] int id)
        {
            try
            {
                await _teamStateRepository.Remove(id);
            }
            catch
            {
                return StatusCode(404, "Not Found Item");
            }

            return Ok("Success");
        }

    }
}
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
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _teamRepository.Find(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetTeams()
        {
            return new ObjectResult(_teamRepository.GetAll());
        }


        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> PostTeam([FromBody] Teams team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _teamRepository.Add(team);

            return Content("created_id");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> deleteTeam([FromRoute] string id)
        {
            try
            {
            await _teamRepository.Remove(id);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok("Success");
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> PutTeam(Teams team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _teamRepository.Update(team);
            }
            catch
            {
                return StatusCode(500, "Something Wrong");
            }

            return Ok("Success");
        }

    }
}
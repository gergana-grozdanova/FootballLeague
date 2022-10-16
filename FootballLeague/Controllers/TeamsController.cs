using AutoMapper;
using FootballLeague.Domain.Abstractions.Services;
using FootballLeague.Domain.Dtos;
using FootballLeague.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Controllers
{
    [ApiController]
    [Route("api/teams")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;
        public TeamsController(ITeamService teamService,IMapper mapper)
        {
            _teamService = teamService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("ranking")]
        public async Task<IActionResult> GetRanked()
        {
            var dtos = await _teamService.RankedTeams();
            return Ok(dtos.Select(t => _mapper.Map<TeamModel>(t)).ToList());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var dtos = await _teamService.GetAllAsync();
            return Ok(dtos.Select(t=>_mapper.Map<TeamModel>(t)).ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var dto = await _teamService.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateTeamModel dto)
        {

            var mapped = _mapper.Map<TeamDto>(dto);
            var team = await _teamService.CreateAsync(mapped);
            return CreatedAtAction(nameof(GetById), new { id = team.Id }, team);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        {
            await _teamService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{teamId}")]
        public async Task<IActionResult> UpdateAnimal([FromRoute] string teamId, [FromBody] CreateTeamModel model)
        {
            var teamDto = _mapper.Map<TeamDto>(model);
            teamDto.Id = teamId;

            await _teamService.UpdateAsync(teamDto);
            return NoContent();
        }
    }
}

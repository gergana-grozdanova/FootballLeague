using AutoMapper;
using FootballLeague.Domain.Abstractions.Services;
using FootballLeague.Domain.Dtos;
using FootballLeague.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Controllers
{
    [ApiController]
    [Route("api/matches")]
    public class MatchController : Controller
    {
        private readonly IMatchService _matchService;
        private readonly IMapper _mapper;
        public MatchController(IMatchService matchService, IMapper mapper)
        {
            _matchService = matchService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var dtos = await _matchService.GetAllAsync();
            return Ok(dtos.Select(t => _mapper.Map<MatchModel>(t)).ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var dto = await _matchService.GetByIdAsync(id);
            if (dto == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MatchModel>(dto));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateMatchModel dto)
        {

            var mapped = _mapper.Map<MatchDto>(dto);
            var team = await _matchService.CreateAsync(mapped);
            return CreatedAtAction(nameof(GetById), new { id = team.Id }, team);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromQuery] string id)
        {
            await _matchService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{matchId}")]
        public async Task<IActionResult> UpdateAnimal([FromRoute] string matchId, [FromBody] CreateMatchModel model)
        {
            var matchDto = _mapper.Map<MatchDto>(model);
            matchDto.Id = matchId;

            await _matchService.UpdateAsync(matchDto);
            return NoContent();
        }
    }
}

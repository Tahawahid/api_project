using api_project.api.CustomActionFilter;
using api_project.api.Model.Domain;
using api_project.api.Model.DTO;
using api_project.api.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_project.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        // POST: api/walks
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateAsync([FromBody] AddWalksRequestDto addWalksRequestDto)
        {
            var walk = mapper.Map<Walk>(addWalksRequestDto);

            await walkRepository.CreateAsync(walk);

            var walkDto = mapper.Map<WalkDto>(walk);

            return Ok(walkDto);
        }

        // GET: api/walks
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var walks = await walkRepository.GetAllAsync();
            var walkDtos = mapper.Map<List<WalkDto>>(walks);
            return Ok(walkDtos);
        }

        // GET: api/walks/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var walk = await walkRepository.GetByIdAsync(id);
            if (walk == null)
            {
                return NotFound();
            }
            var walkDto = mapper.Map<WalkDto>(walk);
            return Ok(walkDto);
        }

        // PUT: api/walks/{id}
        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            
            var walk = mapper.Map<Walk>(updateWalkRequestDto);
            walk.Id = id;
            var updatedWalk = await walkRepository.UpdateAsync(walk);
            if (updatedWalk == null)
            {
                return NotFound();
            }
            var walkDto = mapper.Map<WalkDto>(updatedWalk);
            return Ok(walkDto);
        }

        // DELETE: api/walks/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var deletedWalk = await walkRepository.DeleteAsync(id);
            if (deletedWalk == null)
            {
                return NotFound();
            }
            var walkDto = mapper.Map<WalkDto>(deletedWalk);
            return Ok(walkDto);
        }   
    }
}

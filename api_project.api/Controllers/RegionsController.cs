using api_project.api.Data;
using api_project.api.Model.Domain;
using api_project.api.Model.DTO;
using api_project.api.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_project.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly ApiProjectDBContext dbContext;
        private readonly IRegionRepositories regionRepositories;
        private readonly IMapper mapper;

        public RegionsController(ApiProjectDBContext dbContext, IRegionRepositories regionRepositories, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepositories = regionRepositories;
            this.mapper = mapper;
        }

        // Get All Regions
        [HttpGet]
        public async Task<IActionResult> GetRegions()
        {
            // Fetch all regions from the database using the repository
            var regions = await regionRepositories.GetAllRegionsAsync();

            // Map the domain model to DTO using AutoMapper
            var regionsDto =  mapper.Map<List<Regions>>(regions);

            return Ok(regionsDto);
        }

        /* Get Regions By ID */
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetRegionsID(Guid id)
        {
            var regionDomain = await regionRepositories.GetRegionByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            // Map the domain model to DTO using AutoMapper
            var regionDto = mapper.Map<RegionDto>(regionDomain);


            return Ok(regionDto);
        }

        /* Add Region */
        [HttpPost]
        public async Task<IActionResult> AddRegion([FromBody] AddRegionRequestDto AddRegion)
        {
            // Mapping the AddRegionRequestDto to the Regions domain model
            var regionDomain = mapper.Map<Regions>(AddRegion);

            // Add the region to the database using the repository
            regionDomain = await regionRepositories.AddRegionAsync(regionDomain);

            // Mapping the added region domain model to the RegionDto
            var RegionDto = mapper.Map<RegionDto>(regionDomain); 

            return CreatedAtAction(nameof(GetRegionsID), new { id = RegionDto.Id }, RegionDto);
        }

        // Update the Region
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegion)
        {
            // Mapping the UpdateRegionRequestDto to the Regions domain model
            var regionDomainModel = mapper.Map<Regions>(updateRegion);

            // Update the region in the database using the repository
            regionDomainModel = await regionRepositories.UpdateRegionAsync(id, regionDomainModel);

            // If the region was not found, return NotFound
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // Map the updated domain model to DTO
            var regionDt0 = mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDt0);
        }

        // Delete the Region
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // Delete the region from the database using the repository
            var regionDomain = await regionRepositories.DeleteRegionAsync(id);

            // If the region was not found, return NotFound
            if (regionDomain == null)
            {
                return NotFound();
            }

            // Map the deleted domain model to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomain);
            
            return Ok(regionDto);
        }
    }
}

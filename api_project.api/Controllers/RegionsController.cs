using api_project.api.Data;
using api_project.api.Model.Domain;
using api_project.api.Model.DTO;
using api_project.api.Repositories;
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

        public RegionsController(ApiProjectDBContext dbContext, IRegionRepositories regionRepositories)
        {
            this.dbContext = dbContext;
            this.regionRepositories = regionRepositories;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetRegions()
        {
            var regions = await regionRepositories.GetAllRegionsAsync();

            var regionsDto = regions.Select(x => new RegionDto
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                RegionImageUrl = x.RegionImageUrl
            }).ToList();

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

            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            return Ok(regionDto);
        }

        /* Add Region */
        [HttpPost]
        public async Task<IActionResult> AddRegion([FromBody] AddRegionRequestDto AddRegion)
        {
            if (AddRegion == null)
            {
                return BadRequest();
            }
            var regionDomain = new Regions
            {
                Id = Guid.NewGuid(),
                Code = AddRegion.Code,
                Name = AddRegion.Name,
                RegionImageUrl = AddRegion.RegionImageUrl
            };
            await dbContext.Regions.AddAsync(regionDomain);
            await dbContext.SaveChangesAsync();

            var RegionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetRegionsID), new { id = RegionDto.Id }, RegionDto);
        }

        // Update the Region
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegion)
        {
            var regionDomainModel = new Regions
            {
                Code = updateRegion.Code,
                Name = updateRegion.Name,
                RegionImageUrl = updateRegion.RegionImageUrl
            };

            regionDomainModel = await regionRepositories.UpdateRegionAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            var regionDt0 = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok(regionDt0);
        }


        // Delete the Region
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomain = await regionRepositories.DeleteRegionAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            
            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            return Ok(regionDto);
        } 
    }
}

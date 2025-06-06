using api_project.api.Data;
using api_project.api.Model.Domain;
using api_project.api.Model.DTO;
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
        public RegionsController(ApiProjectDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetRegions()
        {
            var regions = await dbContext.Regions.ToListAsync();

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
            var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
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

        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegion)
        {
            if (updateRegion == null)
            {
                return BadRequest();
            }
            var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            regionDomain.Code = updateRegion.Code;
            regionDomain.Name = updateRegion.Name;
            regionDomain.RegionImageUrl = updateRegion.RegionImageUrl;
            await dbContext.SaveChangesAsync();
            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            dbContext.Regions.Remove(regionDomain);
            await dbContext.SaveChangesAsync();
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

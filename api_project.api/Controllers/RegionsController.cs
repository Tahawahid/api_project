using api_project.api.Data;
using api_project.api.Model.Domain;
using api_project.api.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetRegions()
        {
            var regions =  dbContext.Regions.ToList();

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
        public IActionResult GetRegionsID(Guid id) { 
            var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);
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

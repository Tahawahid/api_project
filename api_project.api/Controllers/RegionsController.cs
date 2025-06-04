using api_project.api.Model.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_project.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRegions()
        {
            // This is a placeholder for the actual implementation.
            // You would typically fetch regions from a database or another service.
            var regions = new List<Regions>
            {
              new Regions
              {
                Id = Guid.NewGuid(),
                Name = "Karachi",
                Code = "Khi",
                RegionImageUrl = "https://images.unsplash.com/photo-1493612276216-ee3925520721?q=80&w=1964&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
              },
              new Regions {
                Id = Guid.NewGuid(),
                Name = "Lahore",
                Code = "lah",
                RegionImageUrl = "https://images.unsplash.com/photo-1493612276216-ee3925520721?q=80&w=1964&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
              },
              new Regions {
                Id = Guid.NewGuid(),
                Name = "Peshawar",
                Code = "PSH",
                RegionImageUrl = "https://images.unsplash.com/photo-1493612276216-ee3925520721?q=80&w=1964&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
              }
            };

            return Ok(regions);
        }
    }
}

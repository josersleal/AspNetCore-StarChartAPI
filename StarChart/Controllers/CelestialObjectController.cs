using Microsoft.AspNetCore.Mvc;
using StarChart.Data;

namespace StarChart.Controllers
{
  [Route("")]
  [ApiController]
  public class CelestialObjectController : ControllerBase
  {
    public ApplicationDbContext context { get; set; }

    public CelestialObjectController(ApplicationDbContext context)
    {
      this.context = context;
    }
  }
}
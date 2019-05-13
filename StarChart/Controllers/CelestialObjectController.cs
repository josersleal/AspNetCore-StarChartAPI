using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;

namespace StarChart.Controllers
{
  [Route("")]
  [ApiController]
  public class CelestialObjectController : ControllerBase
  {
      public CelestialObjectController()
      {
          
      }
    private readonly ApplicationDbContext _context;

    public CelestialObjectController(ApplicationDbContext context)
    {
      this._context = context;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        var celestialObjs = _context.CelestialObjects.ToList();
        foreach (var co in celestialObjs)
        {
        co.Satellites = celestialObjs.Where(e => e.OrbitedObjectId == co.Id).ToList();
      }
      return Ok(celestialObjs);
    }

    [HttpGet("{name}", Name = "GetByName")]
    public IActionResult GetByName(string name)
    {
      var celestialObjs = _context.CelestialObjects.Where(e => e.Name == name).ToList();
      if (!celestialObjs.Any()) return NotFound();
      foreach (var co in celestialObjs)
      {
        co.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == co.Id).ToList();
      }
      return Ok(celestialObjs);
    }

    [HttpGet("{id:int}", Name = "GetById")]
    public IActionResult GetById(int id)
    {
      var celestialObj = _context.CelestialObjects.Find(id);
      if (celestialObj == null) return NotFound();
      celestialObj.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == id).ToList();
      return Ok(celestialObj);
    }
  }
}
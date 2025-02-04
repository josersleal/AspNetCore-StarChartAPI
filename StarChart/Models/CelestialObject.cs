using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarChart.Models
{
    public class CelestialObject
    {
        public CelestialObject(int id, string name)
        {
            this.Id = id;
            this.Name = name;

        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? OrbitedObjectId { get; set; }
        [NotMapped]
        public List<CelestialObject> Satellites { get; set; }
        public System.TimeSpan OrbitalPeriod { get; set; }
    }
}
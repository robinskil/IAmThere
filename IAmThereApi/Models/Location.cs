using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IAmThereApi.Models
{
    public class Location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Longitude { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public LocationDefinitionMode LocationDefinitionMode { get; set; }
        [Required]
        public Guid UserId { get; set; }

        public User User { get; set; }
    }

    public enum LocationDefinitionMode
    {
        Arrive,
        There,
        Leave,
        Unknown,
    }
}

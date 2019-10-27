using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IAmThereApi.RequestModels
{
    public class UpdateLocationModel
    {
        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Longitude { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IAmThereApi.Models;
using NJsonSchema.Annotations;

namespace IAmThereApi.RequestModels
{
    public class CreateGroupModel
    {
        [Required]
        public string GroupName { get; set; }
        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Longitude { get; set; }
        [Required]
        public int AreaSize { get; set; }
    }
}

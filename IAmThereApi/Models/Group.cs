using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IAmThereApi.Models
{
    public class Group
    {
        [Required]
        public Guid GroupId { get; set; }
        [Required]
        public Guid CreatorId { get; set; }
        [Required]
        public string GroupName { get; set; }
        [Required]
        public int PlaceLocationId { get; set; }

        public User Creator { get; set; }
        public Area Area { get; set; }
        public ICollection<UserGroup> Users { get; set; }
    }
}

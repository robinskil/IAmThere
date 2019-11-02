using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IAmThereApi.Models
{
    public class UserGroup
    {
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
        public User User { get; set; }
        public Group Group { get; set; }
    }
}

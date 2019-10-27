using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IAmThereApi.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(255,MinimumLength = 10)]
        public string Password { get; set; }
        [Required]
        [StringLength(60)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(60)]
        public string Lastname { get; set; }

        public ICollection<Location> Locations { get; set; }
        public ICollection<Group> CreatedGroups { get; set; }
        public ICollection<UserGroup> Groups { get; set; }
    }
}

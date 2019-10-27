using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IAmThereApi.RequestModels
{
    public class UserRegisterModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, MinimumLength = 1)]
        public string Email { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 10)]
        public string Password { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 1)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(60,MinimumLength = 1)]
        public string Lastname { get; set; }
    }
}

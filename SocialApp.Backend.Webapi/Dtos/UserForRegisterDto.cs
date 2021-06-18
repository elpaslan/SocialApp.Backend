using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApp.Backend.Webapi.Dtos
{
    public class UserForRegisterDto
    {
        [Required(ErrorMessage = "name gerekli bir alan.")]
        [StringLength(50, MinimumLength = 10)]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Gender { get; set; }
        [Required]
        public string Password { get; set; }



    }
}

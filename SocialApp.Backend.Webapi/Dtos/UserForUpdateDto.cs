using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApp.Backend.Webapi.Dtos
{
    public class UserForUpdateDto
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Introduction { get; set; }
        public string Hobbies { get; set; }
    }
}

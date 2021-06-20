using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApp.Backend.Webapi.Models
{
    public class UserQueryParams
    {
        public int UserId { get; set; }
        public bool Followers { get; set; } = false;
        public bool Followings { get; set; } = false;
    }
}

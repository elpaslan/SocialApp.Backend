using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialApp.Backend.Webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApp.Backend.Webapi.Data
{
    public class SocialContext : IdentityDbContext<User,Role,int>
    {
        public SocialContext(DbContextOptions<SocialContext> options) : base(options)
        {

        }

        public DbSet<Image> Images { get; set; }



    }
}

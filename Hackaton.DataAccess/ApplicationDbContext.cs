﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hackaton.DataAccess.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hackaton.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Tree> Trees { get; set; }
        public virtual DbSet<UserImage> UserImages { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public ApplicationDbContext() : base("HackatonDbCtx")
        {
                
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}

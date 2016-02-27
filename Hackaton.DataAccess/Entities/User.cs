using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Shared;

namespace Hackaton.DataAccess.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }
        public AdvanceLevel AdvanceLevel { get; set; }
        public virtual UserImage Image { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}

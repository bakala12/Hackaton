using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaton.DataAccess.Entities
{
    public class UserImage : Entity
    {
        public byte[] Image { get; set; }
    }
}

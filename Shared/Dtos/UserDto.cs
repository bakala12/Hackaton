using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }
        public AdvanceLevel AdvanceLevel { get; set; }
        public string ApplicationUserId { get; set; }
        public List<EventDto> EventList { get; set; } // augi kazał lel
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class EventDto
    {
        public int Id { get; set; }
        [Description("Miejsce gdzie odbędzię się wydarzenie")]
        public virtual TreeDto Tree { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual EventType EventType { get; set; }
        public DateTime Date { get; set; }
        public virtual UserDto Organizer { get; set; }
        public virtual ICollection<UserDto> Participants { get; set; }
    }
}

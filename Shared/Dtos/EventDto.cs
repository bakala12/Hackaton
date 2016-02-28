using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Typ biegu")]
        public virtual EventType EventType { get; set; }
        [Display(Name = "Data")]
        public DateTime Date { get; set; }
        public virtual UserDto Organizer { get; set; }
        public virtual ICollection<UserDto> Participants { get; set; }
    }
}

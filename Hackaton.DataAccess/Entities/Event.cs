using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaton.DataAccess.Entities
{
    public enum EventType
    {
        [Description("trucht")]
        Jog,
        Sprint,
        [Description("bieg interwałowy")]
        Interval,
        LongRun
    }

    public class Event : Entity
    {
        [Description("Miejsce gdzie odbędzię się wydarzenie")]
        public virtual Tree Tree { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual EventType EventType { get; set; }
        public DateTime Date { get; set; }
        public virtual User Organizer { get; set; }
        public virtual ICollection<User> Participants { get; set; }
    }

}

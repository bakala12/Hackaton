using System.ComponentModel;

namespace Shared
{
    public enum EventType
    {
        [Description("trucht")]
        Jog,
        [Description("strint")]
        Sprint,
        [Description("bieg interwałowy")]
        Interval,
        [Description("bieg długodystansowy")]
        LongRun
    }
}
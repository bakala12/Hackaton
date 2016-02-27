using System.ComponentModel;

namespace Shared
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
}
using System.ComponentModel;

namespace Shared
{
    public enum AdvanceLevel
    {
        [Description("początkujący")]
        Beginner,
        [Description("nowicjusz")]
        Novice,
        [Description("średniozaawansowany")]
        Medium,
        [Description("expert")]
        Expert
    }
}
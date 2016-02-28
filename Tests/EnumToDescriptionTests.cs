using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared;

namespace Tests
{
    [TestClass]
    public class EnumToDescriptionTests
    {
        [TestMethod]
        public void ConvertEventTypeToDescription_ForLongRun()
        {
            var result = EventType.LongRun.GetDescription();
            const string description = "bieg długodystansowy";
            Assert.AreEqual(result, description);
        }
    }
}

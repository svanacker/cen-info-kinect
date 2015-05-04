namespace Org.Cen.Devices.Pid.Com
{
    using NUnit.Framework;

    public class PidDebugOutDataTest
    {
        [Test]
        public void ShouldGeneratePidDebugOutData()
        {
            string expected = "pg01";

            PidDebugOutData outData = new PidDebugOutData(InstructionType.Alpha);

            string actual = outData.getMessage();
            Assert.AreEqual(expected, actual);
        }

    }
}

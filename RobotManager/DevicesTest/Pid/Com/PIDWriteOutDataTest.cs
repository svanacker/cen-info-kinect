namespace Org.Cen.Devices.Pid.Com
{
    using NUnit.Framework;

    public class PidWriteOutDataTest
    {
        [Test]
        public void ShouldGeneratePidWriteOutData()
        {
            string expected = "pw01-12-34-56-78";

            PIDWriteOutData outData = new PIDWriteOutData(1, new PidData(0x12, 0x34, 0x56, 0x78));

            string actual = outData.GetMessage();
            Assert.AreEqual(expected, actual);
        }
    }
}

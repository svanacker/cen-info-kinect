namespace Org.Cen.Devices.Robot.Start.Com
{
    using NUnit.Framework;
    using Org.Cen.Devices.Robot;

    public class StartMatchWritePositionOutDataTest
    {
        [Test]
        public void ShouldGenerateMatchWritePositionOutData()
        {
            string expected = "!P01-1234-5678-9012";

            StartMatchReadPositionInDataDecoder decoder = new StartMatchReadPositionInDataDecoder();
            StartMatchWritePositionOutData outData = new StartMatchWritePositionOutData(MatchSide.Green, 0x1234, 0x5678,
                0x9012);

            string actual = outData.getMessage();

            Assert.AreEqual(expected, actual);
        }
    }
}

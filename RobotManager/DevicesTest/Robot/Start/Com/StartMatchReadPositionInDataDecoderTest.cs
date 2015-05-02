namespace Org.Cen.Devices.Robot.Start.Com
{
    using NUnit.Framework;
    using Org.Cen.Devices.Robot;

    public class StartMatchReadPositionInDataDecoderTest
    {
        [Test]
        public void ShouldDecodeStartMatchReadPositionInData()
        {
            string data = "a!p01-1234-5678-9012";

            StartMatchReadPositionInDataDecoder decoder = new StartMatchReadPositionInDataDecoder();
            StartMatchReadPositionInData inData = (StartMatchReadPositionInData)decoder.Decode(data);

            Assert.AreEqual(MatchSide.Green, inData.Side);
            Assert.AreEqual(0x1234, inData.X);
            Assert.AreEqual(0x5678, inData.Y);
            Assert.AreEqual(0x9012, inData.AngleDeciDegree);

            int length = decoder.GetDataLength(StartMatchReadPositionInData.HEADER);
            Assert.AreEqual(length, data.Length);
        }
    }
}

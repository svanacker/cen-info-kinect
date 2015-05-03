namespace Org.Cen.Devices.Robot.End.Com
{
    using NUnit.Framework;

    public class EndMatchReadTimeLeftInDataDecoderTest
    {
        [Test]
        public void ShouldDecodeStartMatchReadPositionInData()
        {
            string data = "aet12";

            EndMatchReadTimeLeftInDataDecoder decoder = new EndMatchReadTimeLeftInDataDecoder();
            EndMatchReadTimeLeftInData inData = (EndMatchReadTimeLeftInData)decoder.Decode(data);

            Assert.AreEqual(0x12, inData.TimeLeft);

            int length = decoder.GetDataLength(EndMatchReadTimeLeftInData.HEADER);
            Assert.AreEqual(length, data.Length);
        }
    }
}

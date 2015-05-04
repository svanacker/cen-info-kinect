namespace Org.Cen.Devices.Pid.Com
{
    using NUnit.Framework;

    public class PidReadInDataDecoderTest
    {
        [Test]
        public void ShouldDecodePidReadInDataDecoder()
        {
            string data = "apr01-12-34-56-78";

            PidReadInDataDecoder decoder = new PidReadInDataDecoder();
            PIDReadInData inData = (PIDReadInData)decoder.Decode(data);

            PidData pidData = inData.Data;
            Assert.AreEqual(0x01, inData.Index);

            Assert.AreEqual(0x12, pidData.P);
            Assert.AreEqual(0x34, pidData.I);
            Assert.AreEqual(0x56, pidData.D);
            Assert.AreEqual(0x78, pidData.MaxI);

            int length = decoder.GetDataLength(PIDReadInData.HEADER);
            Assert.AreEqual(length, data.Length);
        }
    }
}
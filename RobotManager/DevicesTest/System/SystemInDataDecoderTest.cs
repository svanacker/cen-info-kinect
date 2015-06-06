namespace Org.Cen.Devices.System
{
    using Com;
    using NUnit.Framework;
    
    public class SystemInDataDecoderTest
    {
        [Test]
        public void Should_Decode_SystemGetLastErrorReadInData()
        {
            string data = "aSe1234";

            SystemGetLastErrorInDataDecoder decoder = new SystemGetLastErrorInDataDecoder();
            SystemGetLastErrorInData inData = (SystemGetLastErrorInData) decoder.Decode(data);

            Assert.AreEqual(0x1234, inData.LastError);

            int length = decoder.GetDataLength(null);
            Assert.AreEqual(length, data.Length);
        }
    }
}

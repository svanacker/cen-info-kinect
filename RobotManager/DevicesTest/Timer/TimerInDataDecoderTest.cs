namespace Org.Cen.Devices.Timer
{
    using Com;
    using NUnit.Framework;

    public class TimerInDataDecoderTest
    {
        [Test]
        public void Should_Decode_TimerReadInData()
        {
            string data = "aVc12";

            TimerReadCountInDataDecoder decoder = new TimerReadCountInDataDecoder();
            TimerReadCountInData inData = (TimerReadCountInData)decoder.Decode(data);

            Assert.AreEqual(0x12, inData.Count);

            int length = decoder.GetDataLength(null);
            Assert.AreEqual(length, data.Length);
        }

        [Test]
        public void Should_Decode_TimerIsTimeoutInData()
        {
            string data = "aVt12-1";

            TimerReadIsTimeoutInDataDecoder decoder = new TimerReadIsTimeoutInDataDecoder();
            TimerReadIsTimeoutInData inData = (TimerReadIsTimeoutInData)decoder.Decode(data);

            Assert.AreEqual(0x12, inData.TimerIndex);
            Assert.AreEqual(true, inData.TimeOut);

            int length = decoder.GetDataLength(null);
            Assert.AreEqual(length, data.Length);
        }

        [Test]
        public void Should_Decode_TimeInData()
        {
            string data = "aVr12-34-5678-9012-345678-901234-1";

            TimerReadInDataDecoder decoder = new TimerReadInDataDecoder();
            TimerReadInData inData = (TimerReadInData)decoder.Decode(data);

            Assert.AreEqual(0x12, inData.Index);
            Assert.AreEqual(0x34, inData.Code);
            Assert.AreEqual(0x5678, inData.Diviser);
            Assert.AreEqual(0x9012, inData.InternalCounter);
            Assert.AreEqual(0x345678, inData.Time);
            Assert.AreEqual(0x901234, inData.MarkTime);
            Assert.AreEqual(true, inData.Enabled);

            int length = decoder.GetDataLength(null);
            Assert.AreEqual(length, data.Length);
        }

        [Test]
        public void Should_Decode_TimerWriteMarkInData()
        {
            string data = "aVM123456";

            TimerWriteMarkInDataDecoder decoder = new TimerWriteMarkInDataDecoder();
            TimerWriteMarkInData inData = (TimerWriteMarkInData)decoder.Decode(data);

            Assert.AreEqual(0x123456, inData.TimerMark);

            int length = decoder.GetDataLength(null);
            Assert.AreEqual(length, data.Length);
        }
    }
}

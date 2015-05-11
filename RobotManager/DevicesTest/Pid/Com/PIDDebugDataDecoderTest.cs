namespace Org.Cen.Devices.Pid.Com
{
    using NUnit.Framework;

    public class PidDebugDataDecoderTest
    {
        [Test]
        public void ShouldDecodePidDebugData()
        {
            string data = "apg01-1234-56-789012-345678-6012-3456-7890-1234-5678";

            PIDDebugDataDecoder decoder = new PIDDebugDataDecoder();
            PIDDebugInData inData = (PIDDebugInData)decoder.Decode(data);

            PIDDebugData pidDebugData = inData.PIDDebugData;
            Assert.AreEqual(0x01, pidDebugData.InstructionType);
            Assert.AreEqual(0x1234, pidDebugData.PidTime);
            Assert.AreEqual(0x56, pidDebugData.PidType);
            Assert.AreEqual(0x789012, pidDebugData.NormalPosition);
            Assert.AreEqual(0x345678, pidDebugData.Position);
            Assert.AreEqual(0x6012, pidDebugData.Error);
            Assert.AreEqual(0x3456, pidDebugData.U);

            // TODO
            /*
            Assert.AreEqual(0x7890, pidDebugData.EndMotionIntegralTime);
            Assert.AreEqual(0x1234, pidDebugData.EndMotionAbsDeltaPositionIntegral);
            Assert.AreEqual(0x5678, pidDebugData.EndMotionUIntegral);
            */

            int length = decoder.GetDataLength(PIDDebugInData.HEADER);
            Assert.AreEqual(length, data.Length);
        }
    }
}
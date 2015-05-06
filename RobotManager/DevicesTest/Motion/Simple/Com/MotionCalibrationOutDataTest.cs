namespace Org.Cen.Devices.Motion.Simple.Com
{
    using NUnit.Framework;
    using Robot.Start.Com;

    public class MotionCalibrationOutDataTest
    {
        [Test]
        public void ShouldGenerateMotionCalibrationOutData()
        {
            string expected = "M@01-1234";

            MotionCalibrationOutData outData = new MotionCalibrationOutData(MotionCalibrationOutData.CalibrationDirection.Rigth, 0x1234);

            string actual = outData.getMessage();

            Assert.AreEqual(expected, actual);
        }
    }
}

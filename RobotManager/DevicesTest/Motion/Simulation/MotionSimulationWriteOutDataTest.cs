using Org.Cen.Devices.Motion.Simulation.Com;

namespace Org.Cen.Devices.Motion.Simulation
{
    using NUnit.Framework;

    public class MotionSimulationWriteOutDataTest
    {
        [Test]
        public void ShouldGenerateMotionSimulationWriteOutData()
        {
            string expected = "/w101";

            MotionSimulationData data = new MotionSimulationData(true, false, true);
            MotionSimulationWriteOutData outData = new MotionSimulationWriteOutData(data);

            string actual = outData.getMessage();
            Assert.AreEqual(expected, actual);
        }
    }
}

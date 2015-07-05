namespace Org.Cen.RobotManager
{
    using NUnit.Framework;
    using Org.Cen.RobotManager.Controls;

    public class InputHistoryTest
    {
        [Test]
        public void Should_Input_History_Provide_Completion()
        {
            InputHistory history = new InputHistory();

            history.AddEntry("mw2020");
            history.AddEntry("mw2020");
            history.AddEntry("titi");
            history.AddEntry("toto");
            history.AddEntry("tata");


            string actual = history.GetMostCloseTo("mw2");
            Assert.AreEqual("mw2020", actual);
        }
    }
}

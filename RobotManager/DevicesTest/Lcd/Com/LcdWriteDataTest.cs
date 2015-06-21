namespace Org.Cen.Devices.Lcd.Com
{
    using global::System;
    using NUnit.Framework;
    public class LcdWriteDataTest
    {
        [Test]
        public void ShouldWriteLcdData4()
        {
            //Header = Lw
            String dataExpected = "defg";
            //Result expected : Lw0464656667 because lenght = 4, d in hexa is 64 e is 65...

            LcdWriteData writeData = new LcdWriteData(dataExpected);

            string result = writeData.GetMessage();

            Assert.AreEqual("Lw64656667", result);
        }

        [Test]
        public void ShouldWriteLcdData2()
        {
            //Header = Lw
            String dataExpected = "hi";
            //Result expected : Lw68690000 because h = 68, i = 69 and nothing = 0000.

            LcdWriteData writeData = new LcdWriteData(dataExpected);

            string result = writeData.GetMessage();

            Assert.AreEqual("Lw68690000", result);
        }
    }
}
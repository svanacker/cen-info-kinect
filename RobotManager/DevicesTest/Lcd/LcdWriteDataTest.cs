using System;
using System.Diagnostics;
using Org.Cen.Devices.Lcd.Com;

namespace Org.Cen.Devices.Lcd
{
    using NUnit.Framework;
    public class LcdWriteDataTest
    {
        [Test]
        public void ShouldWriteLcdData4()
        {
            //Header = Lw
            int length = 4;
            String dataExpected = "defg";
            //Result expected : Lw0464656667 because d in hexa is 64 e is 65...

            LcdWriteData writeData = new LcdWriteData(length, dataExpected);

            string result = writeData.getMessage();
            Debug.WriteLine(result);

            Assert.AreEqual("Lw0464656667", result);
        }

        [Test]
        public void ShouldWriteLcdData2()
        {
            //Header = Lw
            int length = 2;
            String dataExpected = "hi";
            //Result expected : Lw6869

            LcdWriteData writeData = new LcdWriteData(length, dataExpected);

            string result = writeData.getMessage();

            Assert.AreEqual("Lw0268690000", result);
        }
    }
}
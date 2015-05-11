namespace Org.Cen.Devices.Eeprom.Com
{
    using Cen.Com.In;

    public class EepromWriteByteBlockInData : InData
    {
        public const string HEADER = "EB";

        public override string ToString()
        {
            return GetType().Name.ToString();
        }
    }
}

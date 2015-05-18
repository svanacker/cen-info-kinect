namespace Org.Cen.Devices.Lcd.Com
{
    using global::System;
    using global::System.Text;
    using Org.Cen.Communication.Utils;
    using Org.Cen.Com.Out;

    public class LcdWriteData : OutData
    {
        public const string HEADER = "Lw";

        public string Data;
        public int Length;

        public const int MESSAGE_LENGTH = 4;

        public LcdWriteData(int length, string data)
            : base()
        {
            if (data.Length > MESSAGE_LENGTH)
            {
                throw new ArgumentException("Parameter must be a string with four char", "data");
            }
            Data = data;
            Length = length;
        }

        public override string getArguments()
        {
            // char array for convert message to write on the LCD
            char[] character = this.Data.ToCharArray();

            // String to return
            StringBuilder result = new StringBuilder();
            string lengthAsString = DataParserUtils.format(Length, 2);
            result.Append(lengthAsString);
            
            // Add the letters to write
            for (int i = 0; i < MESSAGE_LENGTH; i++)
            {
                string charAsHexString = "00";
                if (i < Length)
                {
                    charAsHexString = DataParserUtils.format((int) character[i], 2);
                }
                result.Append(charAsHexString);
            }
            return result.ToString();
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}

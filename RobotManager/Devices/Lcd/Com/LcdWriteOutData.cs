namespace Org.Cen.Devices.Lcd.Com
{
    using Communication.Out;
    using global::System;
    using global::System.Text;
    using Org.Cen.Communication.Utils;
    
    public class LcdWriteOutData : OutData
    {
        public const string HEADER = "Lw";

        public string Data;

        public const int MESSAGE_LENGTH = 4;

        public LcdWriteOutData(string data)
            : base()
        {
            if (data.Length > MESSAGE_LENGTH)
            {
                throw new ArgumentException("Parameter must be a string with four char", "data");
            }
            Data = data;
        }

        public override string GetArguments()
        {
            // char array for convert message to write on the LCD
            char[] character = this.Data.ToCharArray();

            // String to return
            StringBuilder result = new StringBuilder();
            
            // Add the letters to write
            for (int i = 0; i < MESSAGE_LENGTH; i++)
            {
                if (i < character.Length)
                {
                    string charAsHexString = DataParserUtils.format((int) character[i], 2);
                    result.Append(charAsHexString);
                }
                else
                {
                    result.Append("00");
                }
            }
            return result.ToString();
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}

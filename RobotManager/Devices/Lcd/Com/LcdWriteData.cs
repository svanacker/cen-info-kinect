using System;
using System.CodeDom;
using System.Text;
using Org.Cen.Communication.Utils;
using Org.Cen.Com.Out;

namespace Org.Cen.Devices.Lcd.Com
{
    public class LcdWriteData : OutData
    {
        public const string HEADER = "Lw";

        public String Data;
        public int Lenght;

        public LcdWriteData(int lenght, string data)
            : base()
        {
            if (data.Length > 4)
            {
                throw new ArgumentException("Parameter must be a string with four char", "original");
            }
            Data = data;
            Lenght = lenght;
        }

        public override string getArguments()
        {
            //char array for convert message to write on the LCD
            char[] character = this.Data.ToCharArray();
            //String to return
            StringBuilder result = new StringBuilder();
            //Add the letters to write
            for (int i = 0; i < Lenght; i++)
            {
                result.Append(DataParserUtils.format((int) character[i], 2));
            }
            return result.ToString();
        }

        public override string getHeader()
        {
            return HEADER;
        }
    }
}
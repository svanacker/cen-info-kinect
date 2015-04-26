namespace Org.Cen.Com.Utils
{
    using System;
    using System.Globalization;

    /**
     * Set of function useful to read and write data.
     */

    public class ComDataUtils
    {

        /**
	 * Format a boolean value into a string with a length. false is converted as
	 * 0, true as 1
	 * 
	 * @param value
	 *            the boolean value
	 */

        public static string format(bool value)
        {
            if (value)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        /**
	 * Format a value as int into a hexadecimal string with a length.
	 * 
	 * @param value
	 *            the value to convert
	 * @param len
	 *            the length of the string
	 * @return
	 */

        public static string format(int value, int len)
        {
            String result = value.ToString("X" + len);
            int length = result.Length;
            // Test if value is negative => FFFF in front of
            for (int i = 0; i < len - length; i++)
            {
                result = "0" + result;
            }
            if (len < length)
            {
                result = result.Substring(length - len);
            }
            return result.ToUpper();
        }

        public static byte parseByteHex(string data)
        {
            byte value = byte.Parse(data, NumberStyles.HexNumber);
            return value;
        }

        public static long parseShortHex(String data)
        {
            long value = long.Parse(data, NumberStyles.HexNumber);
            if (value > 0x7FFF)
            {
                value -= 0x10000;
            }
            return value;
        }

        public static long parseIntHex(String data)
        {
            long value = long.Parse(data, NumberStyles.HexNumber);
            if (value > 0x7FFFFFFF)
            {
                value -= 0x100000000L;
            }
            return value;
        }

        public static long parseInt5CharHex(String data)
        {
            long value = long.Parse(data, NumberStyles.HexNumber);
            if (value > 0x7FFFF)
            {
                value -= 0x100000L;
            }
            return value;
        }
    }
}
namespace Org.Cen.Com
{
    using System;

    /**
     * The Exception when the data from the serial Interface cannot be parsed.
     */
    public class IllegalComDataException : Exception
    {

        public IllegalComDataException()
        {

        }

        public IllegalComDataException(string message)
            : base(message)
        {

        }
    }
}

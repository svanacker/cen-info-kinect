namespace Org.Cen.Com
{
    /**
     * Exception to check the expected data lenght.
     */
    public class IllegalComDataLengthException : IllegalComDataException
    {

        public IllegalComDataLengthException(int expected, int actual)
            : base("Data length is : " + actual + " but expected is : " + expected)
        {

        }
    }
}

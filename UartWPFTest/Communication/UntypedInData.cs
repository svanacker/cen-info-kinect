namespace Org.Cen.Com
{
    using In;

    /**
     * Corresponds to a data which is not managed by the system.
     */
    public sealed class UntypedInData : InData
    {

        /** The data was sent to the system. */
        private string data;

        /**
         * Constructor
         * 
         * @param data
         *            the data which was received and not managed by the system.
         */
        public UntypedInData(string data)
            : base()
        {
            this.data = data;
        }

        /**
         * Return the data which was received and not managed by the system.
         * 
         * @return the data which was received and not managed by the system.
         */
        public string getData()
        {
            return data;
        }
    }
}

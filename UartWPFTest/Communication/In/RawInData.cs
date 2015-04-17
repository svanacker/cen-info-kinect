namespace Org.Cen.Com.In
{
    using System;


    /**
     * Encapsulation of the data which is sent by the client.
     */
    public class RawInData : AbstractComData
    {

        /**
         * The raw Data which is sent by the client and received by the server.
         */
        protected string rawData;

        /**
         * Returns the raw data which is sent by the client.
         * 
         * @return
         */
        public string getRawData()
        {
            return rawData;
        }

        /**
         * Constructor
         * 
         * @param data
         *            the data which is sent by the client.
         */
        public RawInData(string data)
            : base()
        {
            rawData = data;
        }

        public override string ToString()
        {
            return typeof(RawInData).Name.ToString() + "[rawData=" + rawData + "]";
        }
    }

}

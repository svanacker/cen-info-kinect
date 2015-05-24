namespace Org.Cen.Com.In
{
    using System;
    using Communication;


    /**
     * Encapsulation of the data which is sent by the client.
     */
    public class RawInData : AbstractComData
    {

        /**
         * The raw Data which is sent by the client and received by the server.
         */
        public string RawData { get; protected set; }


        /**
         * Constructor
         * 
         * @param data
         *            the data which is sent by the client.
         */
        public RawInData(string data)
            : base()
        {
            RawData = data;
        }

        public override string ToString()
        {
            return typeof(RawInData).Name.ToString() + "[RawData=" + RawData + "]";
        }
    }

}

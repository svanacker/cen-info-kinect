namespace Org.Cen.Com
{
    using In;

    /**
     * Interface to see information which are exchanged by the server and the
     * client.
     */
    public interface IComDebugListener
    {
        /**
         * Call back method raised when raw data arrives to the server.
         * 
         * @param rawData
         *            the rawData which is sent to the server.
         */
        void OnRawInData(RawInData rawData);
    }
}

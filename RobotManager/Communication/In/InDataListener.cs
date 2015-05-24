namespace Org.Cen.Com.In
{
    using Communication.In;

    /**
     * The interface for event corresponding to data from the port COM. 
     */
    public interface InDataListener {

        /**
         * The interface which is called when data is read from the serial port.
         * 
         * @param data
         *            an object representing the data
         */
        void OnInData(InData data);
    }
}

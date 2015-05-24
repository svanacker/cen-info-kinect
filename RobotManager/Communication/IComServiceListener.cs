namespace Org.Cen.Com
{
    using Communication.In;
    using Communication.Out;
    using In;
    using Out;

    public interface IComServiceListener {

    /**
     * Add listeners to be inform when raw data arrives in the serialPort.
     * 
     * @param listener
     *            the listener which must be notify
     */
    void AddDebugListener(IComDebugListener listener);

    /**
     * Add listeners to be notify when InData Object comes from the client.
     * 
     * @param listener
     *            the listener which must be notify
     */
    void AddInDataListener(InDataListener listener);

    /**
     * Add listeners to be inform when a instruction is sent to the serialPort.
     * 
     * @param listener
     *            the listener which must be notify
     */
    void AddOutDataListener(OutDataListener listener);

    /**
     * Notify all debug observers.
     */
    void FireDebugListener(string data);

    /**
     * Notify all observers that requires to be notify off data which arrives in
     * the serial Port
     */
    void FireInDataListener(InData data);

    /**
     * Notify all observers that requires to be notify when data are sent to the
     * serial Port
     */
    void FireOutDataListener(OutData outData);
}


}

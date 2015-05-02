namespace Org.Cen.Com.Out
{
    /**
     * Interface to be called when there is a notification of sending outData to the
     * board of the robot
     */
    public interface OutDataListener {

        /**
         * The interface which is called when a outData is sent to the board.
         * 
         * @param outData
         *            an object representing the data which is sent to the board.
         */
        void OnOutDataEvent(OutData outData);
    }
}

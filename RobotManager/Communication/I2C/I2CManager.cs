namespace Org.Cen.Communication.I2c
{
    using System.IO;

    public class I2CManager
    {
        public static void SendToSlave(StreamWriter slaveStreamWriter, string text)
        {
            if (slaveStreamWriter == null)
            {
                return;
            }
            // STX
            slaveStreamWriter.Write('\x02');

            // TODO : Address : Add Address !!
            slaveStreamWriter.Write('\x50');

            // Content
            slaveStreamWriter.Write(text);

            // ETX
            slaveStreamWriter.Write('\x03');
            slaveStreamWriter.Flush();
        }

        public static void AskToSendDataFromSlaveToMaster(StreamWriter slaveStreamWriter)
        {
            if (slaveStreamWriter == null)
            {
                return;
            }
            // STX
            slaveStreamWriter.Write('\x02');

            // TODO : Address : Add Read Address !!
            slaveStreamWriter.Write('\x51');

            // ETX
            slaveStreamWriter.Write('\x03');
            slaveStreamWriter.Flush();
        }
    }
}

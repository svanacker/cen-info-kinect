namespace Org.Cen.Communication.Utils
{
    using System.IO;
    using System.IO.Ports;
    using System.Text;

    public class ComManager : IRemoteCommunicationManager
    {
        public IRemoteDataReceivedEvent RemoteDataReceivedEvent { get; private set; }
        public SerialPort Serial { get; private set; }

        public ComManager(IRemoteDataReceivedEvent remoteDataReceivedEvent, string portName)
        {
            this.RemoteDataReceivedEvent = remoteDataReceivedEvent;
            this.Serial = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One);
            Serial.Open();
            Serial.DataReceived += UartReceive;
        }


        private void UartReceive(object sender, SerialDataReceivedEventArgs e)
        {
            int bytesToRead = Serial.BytesToRead;
            if (bytesToRead == 0)
            {
                return;
            }

            byte[] buffer = new byte[bytesToRead];
            Serial.Read(buffer, 0, bytesToRead);
            string newText = Encoding.ASCII.GetString(buffer, 0, bytesToRead);

            RemoteDataReceivedEvent.OnRemoteDataReceived(newText);
        }

        public void WriteToRobot(string text)
        {
            Serial.WriteLine(text);
        }

        public void Dispose()
        {
            Serial.DataReceived -= UartReceive;
            Serial.Close();
        }
    }
}

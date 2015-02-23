
namespace KinectTest2
{
    using System;
    using System.IO.Ports;

    public class UartManager
    {
        private String PortName { get; set; }

        public SerialPort CurrentPort { get; private set; }

        public UartManager(String portName)
        {
            PortName = portName;
        }

        public void Open()
        {
            CurrentPort = new SerialPort(PortName, 115200, Parity.None, 8, StopBits.One);
            CurrentPort.Open();
        }

        public void Close()
        {
            if (CurrentPort == null)
            {
                return;
            }
            CurrentPort.Close();
        }

        public void SendData(String data)
        {
            if (CurrentPort == null)
            {
                return;
            }
            CurrentPort.WriteLine(data);
        }

        // Basic Motors

        public void StopMotors()
        {
            SendData("mc");
        }

        public void RunMotors()
        {
            SendData("mw2020");
        }

        public void BackwardMotors()
        {
            SendData("mwE0E0");
        }

        // Controlled Motion

        public void RotateLeft()
        {
            SendData("mw2000");
        }

        public void RotateRight()
        {
            SendData("mw0020");
        }
    }
}

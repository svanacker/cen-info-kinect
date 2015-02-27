
namespace KinectTest2
{
    using System;
    using System.IO.Ports;
    using System.Threading;
    using System.Threading.Tasks;

    public class UartManager
    {
        private const string POWERLEFT = "38";

        private const string POWERRIGHT = "30";

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
            SendData("mw" + POWERLEFT + POWERRIGHT);
        }

        public void BackwardMotors()
        {
            SendData("mwE0E0");
        }

        // Controlled Motion

        public void RotateLeft()
        {
            SendData("mw" + POWERLEFT + "00");
            var stopTask = new Task(
            () =>
            {
                Thread.Sleep(800);
                this.StopMotors();
            });
            stopTask.Start();
        }

        public void RotateRight()
        {
            SendData("mw" + "00" + POWERRIGHT);
            var stopTask = new Task(
            () =>
            {
                Thread.Sleep(800);
                this.StopMotors();
            });
            stopTask.Start();
        }

        public void StartAc()
        {
            this.SendData("go");
        }

        public void StopAc()
        {
            this.SendData("gf");
        }
    }
}

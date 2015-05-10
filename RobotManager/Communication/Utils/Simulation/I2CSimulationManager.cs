namespace Org.Cen.Communication.Utils.Simulation
{
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    public class I2CSimulationManager : IRemoteCommunicationManager
    {
        private volatile bool stop;
        private bool stopped;
        public PipeServerManager Server { get; private set; }
        public PipeClientManager Client { get; private set; }

        public IRemoteDataReceivedEvent RemoteDataReceivedEvent { get; private set; }

        public I2CSimulationManager(IRemoteDataReceivedEvent remoteDataReceivedEvent)
        {
            RemoteDataReceivedEvent = remoteDataReceivedEvent;
            Server = new PipeServerManager("mainBoardPipe");
            Client = new PipeClientManager("motorBoardPipe", RemoteDataReceivedEvent);

            // Server : Pool from I2C
            Task.Run(() =>
            {

                while (true)
                {
                    if (Client.PipeReader != null)
                    {
                        if (stop)
                        {
                            break;
                        }
                        Thread.Sleep(10);
                        AskToSendDataFromSlaveToMaster();
                    }
                }
                stopped = true;
            });

        }

        public void WriteToRobot(string text)
        {
            if (Server.Writer == null)
            {
                return;
            }
            // STX
            Server.Writer.Write('\x02');

            // TODO : Address : Add Address !!
            Server.Writer.Write('\x50');

            // Content
            Server.Writer.Write(text);

            // ETX
            Server.Writer.Write('\x03');
            Server.Writer.Flush();
        }

        private void AskToSendDataFromSlaveToMaster()
        {
            if (Server.Writer == null)
            {
                return;
            }
            // STX
            Server.Writer.Write('\x02');

            // TODO : Address : Add Read Address !!
            Server.Writer.Write('\x51');

            // ETX
            Server.Writer.Write('\x03');
            Server.Writer.Flush();
        }

        public void Dispose()
        {
            stop = true;
            while (!stopped)
            {
                Thread.Sleep(10);
            }
            Server.Dispose();
            Client.Dispose();
        }
    }
}

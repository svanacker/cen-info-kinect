namespace Org.Cen.Communication.Utils.Simulation
{
    using System;
    using System.IO;
    using System.IO.Pipes;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A Pipe Client received Data from a Remote Pipe.
    /// </summary>
    public class PipeClientManager : IDisposable
    {
        private volatile bool stop;
        public string PipeName { get; private set; }
        public StreamReader PipeReader { get; private set; }
        public NamedPipeClientStream Client { get; private set; }
        public IRemoteDataReceivedEvent RemoteDataReceived { get; private set; }

        public PipeClientManager(string pipeName, IRemoteDataReceivedEvent remoteDataReceivedEvent)
        {
            PipeName = pipeName;
            Task.Run(() =>
            {
                Client = new NamedPipeClientStream(pipeName);
                Client.Connect();
                PipeReader = new StreamReader(Client, Encoding.ASCII);
                while (true)
                {
                    // If it's ask to stop, we go to clean Up Code
                    if (stop)
                    {
                        break;
                    }
                    char value = (char) PipeReader.Read();
                    // No Control Char
                    if (!Char.IsControl(value))
                    {
                        string text = Char.ToString(value);
                        remoteDataReceivedEvent.OnRemoteDataReceived(text);
                    }
                }
                PipeReader.Dispose();
                Client.Dispose();
                Client = null;
            });
        }

        public void Dispose()
        {
            // Ask the Thread to stop
            stop = true;
            while (Client != null)
            {
                Thread.Sleep(10);         
            }
        }
    }
}

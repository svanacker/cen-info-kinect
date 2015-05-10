namespace Org.Cen.Communication.Utils.Simulation
{
    using System;
    using System.Text;

    using System.IO;
    using System.IO.Pipes;
    using System.Security.AccessControl;
    using System.Security.Principal;
    using System.Threading.Tasks;

    /// <summary>
    /// A Pipe server sends Data through a Pipe to a Remote.
    /// </summary>
    public class PipeServerManager : IDisposable
    {
        public StreamWriter Writer { get; private set; }
        public string PipeName { get; private set; }
        public NamedPipeServerStream Server { get; private set; }

        public PipeServerManager(string pipeName)
        {
            PipeName = pipeName;
            Task.Run(() =>
            {
                var sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                var rule = new PipeAccessRule(sid, PipeAccessRights.ReadWrite, AccessControlType.Allow);
                var sec = new PipeSecurity();
                sec.AddAccessRule(rule);

                Server = new NamedPipeServerStream(pipeName, PipeDirection.InOut, 1,
                    PipeTransmissionMode.Byte, PipeOptions.None, 100, 100, sec);
                Server.WaitForConnection();
                Writer = new StreamWriter(Server, Encoding.ASCII);
                Writer.AutoFlush = true;
            });
        }

        public void Dispose()
        {
            Writer.Dispose();
            Server.Dispose();
        }
    }
}

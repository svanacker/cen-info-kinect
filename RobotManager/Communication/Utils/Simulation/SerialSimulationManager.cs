namespace Org.Cen.Communication.Utils.Simulation
{
    using System;
    using System.IO;

    ///
    /// Class which manages the fake Com link between the RobotManager (C#) and the cen-electronic-console.exe
    /// <seealso ref="I2CSimulationManager"/>
    /// 
    public class SerialSimulationManager : IRemoteCommunicationManager
    {
        public PipeServerManager Server { get; private set; }
        public PipeClientManager Client { get; private set; }

        public IRemoteDataReceivedEvent RemoteDataReceivedEvent { get; private set; }

        public SerialSimulationManager(IRemoteDataReceivedEvent remoteDataReceivedEvent)
        {
            RemoteDataReceivedEvent = remoteDataReceivedEvent;
            Server = new PipeServerManager("serialInputPipe1");
            Client = new PipeClientManager("serialOutputPipe1", RemoteDataReceivedEvent);
        }

        public void WriteToRobot(string text)
        {
            if (Server.Writer == null)
            {
                return;
            }

            // Content
            Server.Writer.Write(text);
        }

        public void Dispose()
        {
            Client.Dispose();
            Server.Dispose();
        }
    }
}

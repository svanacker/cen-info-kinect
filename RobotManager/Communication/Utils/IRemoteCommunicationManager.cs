namespace Org.Cen.Communication.Utils
{
    using System;
    using System.IO;

    ///
    /// Interface to control a remote Simulation program like cen-electronic-console.exe
    /// Concrete classe could use I2C (MotorBoard) or Serial (MainBoard).
    /// 
    public interface IRemoteCommunicationManager : IDisposable
    {
        /// <summary>
        /// The Call Back method object which must be used to notify when Data is received.
        /// </summary>
        IRemoteDataReceivedEvent RemoteDataReceivedEvent { get; }

        ///
        /// Write a char to the Robot.
        /// 
        void WriteToRobot(string text);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slaveStreamWriter"></param>
        /// <returns></returns>
        // string ReadFromRobot(StreamWriter slaveStreamWriter);
    }
}

namespace Org.Cen.Communication.Utils
{
    /// <summary>
    /// The interface which must be called when data is received.
    /// </summary>
    public interface IRemoteDataReceivedEvent
    {
        void OnRemoteDataReceived(string text);
    }
}

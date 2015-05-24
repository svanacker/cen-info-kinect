namespace Org.Cen.Communication.Out
{
    public class RawOutData : OutData {

        private string data;

        public RawOutData(string data) : base() {
            this.data = data;
        }

        public override string GetHeader() {
            return data;
        }
    }
}
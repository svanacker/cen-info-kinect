namespace Org.Cen.Com.Out
{
    public class RawOutData : OutData {

        private string data;

	    public RawOutData(string data) : base() {
		    this.data = data;
	    }

	    public override string getHeader() {
		    return data;
	    }
    }
}
namespace Org.Cen.Com.In
{

    /**
     * Class which corresponds to a data which has no Header or which is not
     * recognized by the system.
     */
    public class UntypedInData : InData
    {

        private string data;

        public UntypedInData(string data)
            : base()
        {
            this.data = data;
        }

        public string getData()
        {
            return data;
        }

        public override string ToString()
        {
            return typeof(UntypedInData).Name.ToString() + "[data=" + data.ToString() + "]";
        }
    }
};

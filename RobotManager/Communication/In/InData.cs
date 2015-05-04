namespace Org.Cen.Com.In
{
    using Communication;

    /**
     * Objects which represents the data which comes from the micro-controllers and
     * which must be decrypted.
     */
    public abstract class InData : AbstractComData
    {

        public InData()
            : base()
        {

        }

        public string toString()
        {
            // return getType().getSimpleName();
            return "InData";
        }
    }
}

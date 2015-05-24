namespace Org.Cen.Communication.In
{
    using Communication;

    ///
    /// Objects which represents the data which comes from the micro-controllers and
    /// which must be decrypted.
    /// 
    public abstract class InData : AbstractComData
    {

        protected InData()
            : base()
        {

        }

        public override string ToString()
        {
            return GetType().Name.ToString();
        }
    }
}

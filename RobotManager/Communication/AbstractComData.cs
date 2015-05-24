namespace Org.Cen.Communication
{
    using System;

    ///
    /// The base class of all Data which communicated through the serial PORT (in or out).
    ///
    public abstract class AbstractComData
    {

        // private static SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.SSS");

        ///
        /// The date for the creation of comData. 
        /// 
        protected DateTime CreationDate { get; private set; }

        /// <summary>
        /// Get the Command Header string relative to the in/out command.
        /// </summary>
        protected string CommandHeader { get; set; }

        /// <summary>
        /// Returns the header of the relative device.
        /// </summary>
        protected string DeviceHeader { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected AbstractComData()
        {
            CreationDate = new DateTime();
        }

        /**
         * Returns the creation date of the COM data.
         * 
         * @return the creation date of the COM data
         */
        public string GetCreationDateAsText()
        {
            // TODO :
            //return dateFormat.format(creationDate);
            return null;
        }

        /**
         * Utility method for view.
         * 
         * @return the description of the data
         */
        public string GetDescription()
        {
            return ToString();
        }
    }
}

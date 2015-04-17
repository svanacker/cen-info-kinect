namespace Org.Cen.Com
{
    using System;

    /**
     * The base class of all Data which communicated through the serial PORT (in or
     * out).
     */
    public abstract class AbstractComData
    {

        // private static SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.SSS");

        /**
         * The date for the creation of comData.
         */
        protected DateTime creationDate;

        /**
         * Constructor.
         */
        public AbstractComData()
        {
            creationDate = new DateTime();
        }

        /**
         * Returns the creation date of the COM data.
         * 
         * @return the creation date of the COM data
         */
        public DateTime getCreationDate()
        {
            return creationDate;
        }

        /**
         * Returns the creation date of the COM data.
         * 
         * @return the creation date of the COM data
         */
        public string getCreationDateAsText()
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
        public string getDescription()
        {
            return ToString();
        }
    }
}

namespace Org.Cen.Communication.Out
{
    using System;

    /**
     * Annotation used to reference the list of OutData which must be known in the
     * system.
     */
    public class OutDataSenderAttribute : System.Attribute {

        /**
         * List of "OutData" classes.
         * 
         * @return
         */
        Type[] Classes;
    }


}

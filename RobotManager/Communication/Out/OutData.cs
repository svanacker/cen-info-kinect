namespace Org.Cen.Com.Out
{
    using System;
    using System.Text;
    using Communication;

    /**
     * Objects which represents the data which are sent from the PC to the
     * microcontroller. This object must be subclassed to be used.
     * 
     * @author svanacker
     */
    public abstract class OutData : AbstractComData
    {

        private bool waitForAck;

        /**
         * Constructor.
         */
        public OutData()
            : this(true)
        {
        }

        /**
         * Constructor
         * 
         * @param waitForAck
         *            the value of the waitForAck flag
         * @see setWaitForAck
         */
        public OutData(bool waitForAck)
            : base()
        {
            this.waitForAck = waitForAck;
        }

        /**
         * Returns the arguments of the message.
         * 
         * @return the arguments of the message
         */
        public virtual string getArguments()
        {
            // No arguments by default
            return null;
        }

        /**
         * Returns a string intended for debugging purpose and representing the data
         * contained in this object.
         * 
         * @return a representation of the data contained in this object
         */
        public virtual string getDebugString()
        {
            // Default debug string (no data)
            return "[]";
        }

        /**
         * The header which is the discriminator for each instruction that is send
         * to the client (micro-controller).
         * 
         * @return the header of the message
         */
        public abstract string getHeader();

        /**
         * Returns the message which must be send to the client
         * 
         * @return the message which must be send to the client
         */
        public virtual string getMessage()
        {
            StringBuilder message = new StringBuilder();
            message.Append(getHeader());
            String args = getArguments();
            if (args != null)
            {
                message.Append(args);
            }
            String result = message.ToString();
            return result;
        }

        /**
         * Retrieves the value of the flag indicating whether the COM service has to
         * wait for acknowledgment after sending the data.
         * 
         * @return the value of the waitForAck flag
         */
        public bool getWaitForAck()
        {
            return waitForAck;
        }

        /**
         * Defines whether the COM service has to wait for acknowledgment after
         * sending the data.
         * 
         * @param waitForAck
         *            the value of the waitForAck flag
         */
        public void setWaitForAck(bool waitForAck)
        {
            this.waitForAck = waitForAck;
        }

        // object implementation

        public override int GetHashCode()
        {
            string message = getMessage();
            int result = message.GetHashCode();
            return result;
        }

        public override bool Equals(Object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (GetType() != obj.GetType())
            {
                return false;
            }
            OutData other = (OutData)obj;
            String message = getMessage();
            String otherMessage = other.getMessage();
            if (!message.Equals(otherMessage))
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return GetType().Name + getDebugString();
        }
    }
}

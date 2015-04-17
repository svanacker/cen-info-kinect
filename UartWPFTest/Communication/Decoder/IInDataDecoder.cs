namespace Org.Cen.Com
{
    using System.Collections.Generic;
    using In;

    /**
     * Interface of the decoder class that decodes incomming serial data.
     */
    public interface IInDataDecoder {

        // const int HEADER_LENGTH = 2;

        /**
         * Returns the set of handled data headers.
         * 
         * @return the set of handled data headers
         */
        ISet<string> GetHandledHeaders();

        /**
         * Decode the incomming data string.
         * 
         * @param data
         *            the incomming data string (contains header)
         * @return the data object associated to the incomming data string
         * @throws IllegalComDataException
         *             if the data string could not be decoded
         */
        InData Decode(string data);

        /**
         * Returns the length of the data associated to the specified header string.
         * The returned value does not take into account the size of the header. If
         * the header is not followed by any data, or if the header is not handled
         * by this decoder, the value returned is 0.
         * 
         * @param header
         *            the header string
         * @return the length of the data following the header
         */
        int GetDataLength(string header);
    }

}

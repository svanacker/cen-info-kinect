namespace Org.Cen.Com
{
    using System.Collections.Generic;
    using Communication.In;
    using In;

    /**
     * The service which manage all Decoders.
     */
    public interface IInDataDecodingService
    {

        /**
         * Return the right decoder which must be used to handle the message with
         * the header given in paramters.
         * 
         * @param header
         *            the header for which we must determine the right decoder to
         *            handle in data
         * @return
         */
        IInDataDecoder GetDecoder(string header);

        /**
         * Returns the registered decoders.
         * 
         * @return the registered decoders
         */
        ISet<IInDataDecoder> GetDecoders();

        /**
         * Register a decoder which can handle many message.
         * 
         * @param decoder
         *            the decoder that we want to register in the system.
         */
        void RegisterDecoder(IInDataDecoder decoder);

        /**
         * Build the decoder corresponding to the system.
         * 
         * @param data
         *            the data from the serial interface
         * @return an object encapsulating the message.
         * @throws IllegalComDataException
         */
        InData Decode(string data);
    }

}

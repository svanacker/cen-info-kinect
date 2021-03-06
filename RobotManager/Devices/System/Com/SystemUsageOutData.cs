﻿namespace Org.Cen.Devices.System.Com
{
    using Communication.Out;

    public class SystemUsageOutData : OutData
    {

        /// <summary>
        /// The Header which is used by the message to show the usage of all devices.
        /// </summary>
        public const string HEADER = "Su";

        public SystemUsageOutData()
            : base()
        {
        }

        public override string GetHeader()
        {
            return HEADER;
        }
    }
}

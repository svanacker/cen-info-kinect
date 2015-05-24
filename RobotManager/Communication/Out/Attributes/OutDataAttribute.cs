namespace Org.Cen.Communication.Out.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class OutDataAttribute : Attribute
    {

        /// <summary>
        /// For the moment, a simple letter which is added to the leader linked to the device Header.
        /// </summary>
        public string CommandHeader { get; set; }

        public OutDataAttribute(string commandHeader)
        {
            CommandHeader = commandHeader;
        }
    }
}

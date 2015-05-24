namespace Org.Cen.Communication.Documentation
{
    using System;
    using Com.In;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DeviceParameterAttribute : Attribute
    {

        /**
         * Name of the parameter.
         * @return
         */
        string Name { get; set; }

        /**
         * Length of the parameter (Ex : 2, 4 ...)
         * @return
         */
        int Length { get; set; }

        /**
         * To know if the value is signed or not !
         * @return
         */
        DeviceParameterType Type { get; set; }

        /**
         * Unit (hint)
         * @return
         */
        string Unit { get; set; }

        public DeviceParameterAttribute(string name, int length, DeviceParameterType type)
        {
            Name = name;
            Length = length;
            Type = type;
        }

        public DeviceParameterAttribute(string name, int length, DeviceParameterType type, string unit)
            : this(name, length, type)
        {
            Unit = unit;
        }
    }
}

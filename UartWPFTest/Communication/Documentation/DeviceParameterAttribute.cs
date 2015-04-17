namespace Org.Cen.Com.In
{

    public class DeviceParameterAttribute : System.Attribute
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
    }
}

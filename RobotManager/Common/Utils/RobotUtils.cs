namespace Org.Cen.Common.Utils
{
    using Attributes;
    using Factory;

/**
 * Utility Class to get easily resources around Robot. 
 */

    public class RobotUtils
    {

        public static IRobot getRobot(IRobotServiceProvider provider)
        {
            //IRobotFactory factory = provider.GetService(typeof (IRobotFactory));
            //;
            //return factory.GetRobot();
            return null;
        }

        //public static <E extends IRobotAttribute> E getRobotAttribute(Class<E> attributeType, IRobotServiceProvider provider) {
        //    return getRobot(provider).getAttribute(attributeType);
        //}

    }
}

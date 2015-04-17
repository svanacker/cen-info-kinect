using Org.Cen.Common.Configuration;
using Org.Cen.Common.Device;
using System.Collections.Generic;

namespace Org.Cen.Common
{
    using System;
    using Attributes;


    /**
     * Interface of the robot object.
     */
    public interface IRobot
    {

        /**
         * Returns the attribute value coresponding to the given attribute class.
         * 
         * @param attributeType
         *            the type of the robot attribute to retrieve
         * @return the attribute value
         */
        E GetAttribute<E>(E attributeType) where E : IRobotAttribute;

        /**
         * Returns the list of the attributes of the robot.
         * 
         * @return the list of the attributes
         */
        IList<IRobotAttribute> GetAttributes();

        /**
         * Returns the configuration of the robot.
         * 
         * @return the configuration of the robot
         */
        IRobotConfiguration GetConfiguration();

        /**
         * Returns the list of the devices.
         * 
         * @return the list of the devices
         */
        IList<IRobotDevice> GetDevices();

        /**
         * Returns the name of the robot.
         * 
         * @return the name of the robot
         */
        string GetName();

        /**
         * Sets the configuration of the robot.
         * 
         * @param configuration
         *            the configuration of the robot
         */
        void SetConfiguration(IRobotConfiguration configuration);

        /**
         * Sets the device list of the robot.
         * 
         * @param devices
         *            the device list of the robot
         */
        void SetDevices(IList<IRobotDevice> devices);
    }

}

using System.Collections.Generic;

namespace Org.Cen.Common.Configuration
{
    /**
     * Interface for manipulating the robot configuration. The robot configuration
     * consists of a properties set.
     * 
     * @author Emmanuel ZURMELY
     */
    public interface IRobotConfiguration
    {

        /**
         * Returns the properties set.
         * 
         * @return the properties set
         */
        IDictionary<string, string> GetProperties();

        /**
         * Returns a property value.
         * 
         * @param key
         *            the property key
         * @return the property value or null if the property does not exist
         */
        string GetProperty(string key);

        /**
         * Sets a property.
         * 
         * @param key
         *            the property key
         * @param value
         *            the new property value
         */
        void SetProperty(string key, string value);
    }
}
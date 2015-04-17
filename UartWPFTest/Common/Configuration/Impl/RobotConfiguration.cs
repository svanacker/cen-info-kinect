namespace Org.Cen.Common.Configuration
{
    /**
     * {@link IRobotConfiguration} default implementation.
     * @author Stephane
     *
     */

    using System.Collections.Generic;

    public class RobotConfiguration : IRobotConfiguration
    {

        private IDictionary<string, string> properties;

        public RobotConfiguration()
            : base()
        {
            properties = new Dictionary<string, string>();
        }

        public IDictionary<string, string> GetProperties()
        {
            return properties;
        }

        public string GetProperty(string key)
        {
            string result;
            properties.TryGetValue(key, out result);

            return result;
        }

        public void SetProperty(string key, string value)
        {
            properties.Add(key, value);
        }
    }
}

namespace Org.Cen.Common.Services
{
    /**
     * Base interface for all the services. The services are initialized before the
     * robot object itself. They represent the software services of the robot.
     */
    public interface IRobotService
    {

        /**
         * Sets the services provider that keeps track of all the services available
         * to the robot. This method must be called during the initialization of the
         * service object.
         * 
         * @param provider
         *            the services provider that this service can use to access to
         *            the other services
         */
        void setServicesProvider(IRobotServiceProvider provider);
    }
}

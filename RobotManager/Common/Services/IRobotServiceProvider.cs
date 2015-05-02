namespace Org.Cen.Common
{
    using System.Collections.Generic;
    using Services;


    /**
     * Interface of the robot services provider.
     * 
     * @author Emmanuel ZURMELY
     */
    public interface IRobotServiceProvider
    {

        /**
         * Return the service implementation of the specified service interface.
         * 
         * @param <E>
         *            an interface extending IRobotService
         * @param serviceType
         *            the class type of the required service
         * @return the registered implementation for the required service
         */
        T GetService<T>(T serviceType) where T : class;

        /**
         * Returns a set of all registered services.
         * 
         * @return a set of all registered services
         */
        ISet<IRobotService> GetServices();

        /**
         * Registers a service.
         * 
         * @param <E>
         *            an interface extending IRobotService
         * @param serviceType
         *            the class type of the service to register
         * @param service
         *            the service implementation
         */
        void RegisterService<E>(E serviceType, E service) where E : IRobotService;
    }
}
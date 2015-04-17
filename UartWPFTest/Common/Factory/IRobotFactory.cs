namespace Org.Cen.Common.Factory
{
    using Configuration;
    using Services;


/**
 * Interface of the robot factory. The robot factory is responsible for the
 * specific initialization of a IRobot instance.
 * 
 * @author Emmanuel ZURMELY
 * 
 */
public interface IRobotFactory : IRobotService {
	
	/**
	 * Returns the robot object.
	 * 
	 * @return the robot object
	 */
	IRobot GetRobot();

	/**
	 * Returns the robot configuration.
	 * 
	 * @return the robot configuration
	 */
	IRobotConfiguration GetRobotConfiguration();

	/**
	 * Restarts the robot.
	 */
	void Restart();

	/**
	 * Sets the robot configuration.
	 * 
	 * @param configuration
	 *            the configuration interface to set
	 */
	void SetRobotConfiguration(IRobotConfiguration configuration);
}

}
namespace Org.Cen.Common.Attributes.Impl
{
    using System.Collections;
    using System.Collections.Generic;

    /**
     * Corresponds to the dimension of the robot, the distance between the wheels
     * ...
     * 
     * @author svanacker
     * @version 23/02/2007
     */

    public class RobotDimension
    {

        private const string PROPERTY_DEPTH = "depth";

        private const string PROPERTY_WEIGHT = "weight";

        private const string PROPERTY_WHEELS_DISTANCE = "wheelsDistance";

        private const string PROPERTY_WIDTH = "width";

        private const string PREFIX_MOTOR_LEFT = "motors.left";

        private const string PREFIX_MOTOR_RIGHT = "motors.right";

        /**
     * Depth of the robot in mm.
     */
        private double depth;

        /**
     * Left motor properties.
     */
        private MotorProperties leftMotor;

        /**
     * Right motor properties.
     */
        private MotorProperties rightMotor;

        /**
     * The weight of the robot in kg.
     */
        private double weight;

        /**
     * Distance between the wheels in mm.
     */
        private double wheelsDistance;

        /**
     * Width of the robot in mm.
     */
        private double width;

        public RobotDimension(double width, double depth, double weight, MotorProperties leftMotor,
            MotorProperties rightMotor, double wheelsDistance)
            : base()
        {
            this.depth = depth;
            this.leftMotor = leftMotor;
            this.rightMotor = rightMotor;
            this.weight = weight;
            this.wheelsDistance = wheelsDistance;
            this.width = width;
        }

        public RobotDimension(IDictionary<string, string> properties, string prefix)
            : base()
        {
            leftMotor = new MotorProperties(properties, prefix + PREFIX_MOTOR_LEFT + ".");
            rightMotor = new MotorProperties(properties, prefix + PREFIX_MOTOR_RIGHT + ".");
            setFromProperties(properties, prefix);
        }

        /**
         * Returns the robot's depth.
         */
        public double getDepth()
        {
            return depth;
        }

        public MotorProperties getLeftMotor()
        {
            return leftMotor;
        }

        public MotorProperties getRightMotor()
        {
            return rightMotor;
        }

        public double getWeight()
        {
            return weight;
        }

        /**
         * Return the distance for a wheel distance for each wheel so that the robot
         * can make a rotation
         */
        public double getWheelDistance()
        {
            return wheelsDistance;
        }

        /**
         * Returns the robot's width.
         */
        public double getWidth()
        {
            return width;
        }

        public void setFromProperties(IDictionary<string, string> properties, string prefix)
        {
            //width = PropertiesUtils.getDouble(properties, prefix + PROPERTY_WIDTH);
            //depth = PropertiesUtils.getDouble(properties, prefix + PROPERTY_DEPTH);
            //wheelsDistance = PropertiesUtils.getDouble(properties, prefix + PROPERTY_WHEELS_DISTANCE);
            //weight = PropertiesUtils.getDouble(properties, prefix + PROPERTY_WEIGHT);
        }

        public void setWeight(double weight)
        {
            this.weight = weight;
        }

        public string ToString()
        {
            return GetType().Name + "[width=" + width + ", depth=" + depth + ", wheelsDistance="
                   + wheelsDistance + ", weight=" + weight + " kg, leftMotor: " + leftMotor + ", rightMotor: "
                   + rightMotor + "]";
        }
    }

}
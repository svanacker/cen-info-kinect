namespace Org.Cen.Common.Attributes.Impl
{

    /*
     * Game Area : 
     * 
     * Y__________
     * |         |
     * |         |
     * |    ^    |
     * |    |    |
     * |    |    |
     * |         |
     * |_________|
     *            X
     * The alpha is defined as the angle between Y and the array as in the schema            
     * The X and Y are defined for the center of the robot            
     */

    /**
     * Describes the position of the robot in X, Y, and Alpha The area is described
     * as following : X and Y are in mm Alpha corresponds to the trigonometric angle
     * with the horizontal x axis.
     * 
     * @author svanacker
     * @version 23/02/2007
     */

    public class RobotPosition : IRobotAttribute
    {

        private const string PROPERTY_X = "x";

        private const string PROPERTY_Y = "y";

        private const string PROPERTY_ALPHA = "alphaDegrees";

        /** The position of the robot for Alpha */
        protected double alpha;

        /** The position of the robot for X axis */
        // protected Point2D.Double centralPoint = new Point2D.Double();

        /**
         * Constructor with all Values
         * 
         * @param x
         * @param y
         * @param alpha
         */
        public RobotPosition(double x, double y, double alpha)
            : base()
        {
            // TODO 
        }
    }
}
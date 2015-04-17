namespace Org.Cen.Common
{


    public interface IMotorProperties
    {

        /**
         * Converts an acceleration in mm / second� into pulses / second�.
         */
        double accelerationToAccelerationPulse(double acceleration);

        /**
         * Converts a distance into pulses.
         * 
         * @param distance
         *            a distance in mm
         * @return the number of pulses
         */
        double distanceToPulse(double distance);

        /**
         * Gets the maximum speed in mm / second. The rotation is multiplied by the
         * perimeter of the wheel.
         */
        double getMaxSpeed();

        double getMotorTorque();

        int getPulseCount();

        double getRotationsPerSecond();

        double getWheelDiameter();

        /**
         * Returns the perimeter of the wheel in mm.
         */
        double getWheelPerimeter();

        /**
         * Converts a distance into pulse.
         * 
         * @param pulse
         *            the number of pulses to convert
         * @return the computed distance
         */
        double pulseToDistance(double pulse);

        /**
         * Converts a speed from mm / second into pulse / second.
         */
        double speedToSpeedPulse(double speed);
    }


}

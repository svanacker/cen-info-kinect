namespace Org.Cen.Devices.Pid.Com
{

    /**
     * Encapsulates the parameter to detect the end of motion.
     */
    public class MotionEndDetectionParameter
    {
        /**
         * Defines the delta position integral for which we consider that below this
         * value the robot don't move
         */
        public float AbsDeltaPositionIntegralFactorThreshold { get; set; }

        /**
         * Defines the u integral factor integral for which we consider that there
         * is a blocking. For example, if the value is equal to 4, it indicates that
         * if the average integral of U is more than 4x the normal value of u (with
         * no load), we must consider it as a blocking
         */
        public float MaxUIntegralFactorThreshold { get; set; }

        /**
         * When the robot is very low, the answer of the motor is not linear, and we
         * can thing that the robot is blocked, because, the consign is very high
         * compared to the normal value. So this value is
         */
        public float MaxUIntegralConstantThreshold { get; set; }

        /**
         * TimeRangeAnalysis. It's important to detect on a small range to determine
         * if the robot is blocked or not (to avoid problems with motors). But too
         * short range time analysis give sometimes bad analysis. It's also
         * important to detect on a small range to have a decision of end detection
         * (to continue on next instruction). But too short range time analysis give
         * sometimes bad analysis.
         */
        public int TimeRangeAnalysis { get; set; }

        /**
         * The delay for which we do not try to check the end detection parameter.
         * It avoids that the robot stop immediately the begin of motion, because it
         * consideres that the robot is blocked or has ended his trajectory
         */
        public int NoAnalysisAtStartupTime { get; set; }

        public MotionEndDetectionParameter()
            : base()
        {

        }

        public MotionEndDetectionParameter(float absDeltaPositionIntegralFactorThreshold,
                float maxUIntegralFactorThreshold, float maxUIntegralConstantThreshold, int timeRangeAnalysis,
                int noAnalysisAtStartupTime)
        {
            this.AbsDeltaPositionIntegralFactorThreshold = absDeltaPositionIntegralFactorThreshold;
            this.MaxUIntegralFactorThreshold = maxUIntegralFactorThreshold;
            this.MaxUIntegralConstantThreshold = maxUIntegralConstantThreshold;
            this.TimeRangeAnalysis = timeRangeAnalysis;
            this.NoAnalysisAtStartupTime = noAnalysisAtStartupTime;
        }

        public override string ToString()
        {
            return typeof(MotionEndDetectionParameter).Name + "[absDeltaPositionIntegralFactorThreshold="
                    + AbsDeltaPositionIntegralFactorThreshold + ", maxUIntegralFactorThreshold="
                    + MaxUIntegralFactorThreshold + ", maxUIntegralConstantThreshold=" + MaxUIntegralConstantThreshold
                    + ", timeRangeAnalysis=" + TimeRangeAnalysis + ", noAnalysisAtStartupTime=" + NoAnalysisAtStartupTime
                    + "]";
        }
    }
}

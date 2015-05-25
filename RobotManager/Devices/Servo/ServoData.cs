namespace Org.Cen.Devices.Servo
{
    /// 
    /// Encapsulates Data (Speed, Value) for a servo.
    /// 
    public class ServoData
    {
        public int ServoIndex { get; set; }

        public int ServoSpeed { get; set; }

        public int ServoCurrentPosition { get; set; }

        public int ServoTargetPosition { get; set; }

        public ServoData(int servoIndex, int servoSpeed, int servoTargetPosition)
        {
            ServoIndex = servoIndex;
            ServoSpeed = servoSpeed;
            ServoTargetPosition = servoTargetPosition;
        }

        public ServoData(int servoIndex, int servoSpeed, int servoCurrentPosition, int servoTargetPosition)
        {
            ServoIndex = servoIndex;
            ServoSpeed = servoSpeed;
            ServoCurrentPosition = servoCurrentPosition;
            ServoTargetPosition = servoTargetPosition;
        }
    }
}

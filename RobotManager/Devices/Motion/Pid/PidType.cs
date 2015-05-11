namespace Org.Cen.Devices.Pid
{
    public enum PidType
    {   
        /// <summary>
        /// The mask used to indicate that we want to use value of PID to rotate.
        /// </summary>
        Go = 0,

        /// <summary>
        /// The mask used to indicate that we want to use value of PID to maintain very strongly the position.
        /// </summary>
        Rotate = 1,

        /// <summary>
        /// The mask used to indicate that we want to use value of PID to maintain very strongly the position.
        /// </summary>
        MaintainPosition = 2,

        /// <summary>
        /// The mask used to indicate that we want to adjust the robot to the border of board.
        /// </summary>
        AdjustDirection = 3,

        /// <summary>
        /// The pid for final approach.
        /// </summary>
        FinalApproach = 4
    }
}

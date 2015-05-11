namespace Org.Cen.Devices.Pid
{
    public class PidData
    {
        public int P { get; set; }
        public int I { get; set; }
        public int D { get; set; }
        public int MaxI { get; set; }

        public PidData(int p, int i, int d, int maxI)
        {
            P = p;
            I = i;
            D = d;
            MaxI = maxI;
        }
    }
}

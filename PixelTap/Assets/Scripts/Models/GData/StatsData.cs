using System;

namespace Assets.Scripts.Models.GData
{
    [Serializable]
    public class StatsData
    {
        public Stat BuildPixels;
        public Stat TechPixels;
        public Stat SolvePixels;
        public Stat RawPixels;
        public Stat Energy;

        public StatsData()
        {
            BuildPixels = new Counter(100, 0, int.MaxValue, Tags.Counter_BuildPixels.ToString());
            TechPixels = new Counter(100, 0, int.MaxValue, Tags.Counter_TechPixels.ToString());
            SolvePixels = new Counter(100, 0, int.MaxValue, Tags.Counter_SolvePixels.ToString());
            RawPixels = new Counter(100, 0, int.MaxValue, Tags.Counter_RawPixels.ToString());
            Energy = new SliderCounter(0, 0, 100, Tags.Counter_Energy.ToString());
        }
    }
}
using System;

namespace Assets.Scripts.Models.GData
{
    [Serializable]
    public class StatsData
    {
        public StatData BuildPixels;
        public StatData TechPixels;
        public StatData SolvePixels;
        public StatData RawPixels;
        public StatData Energy;

        public StatsData()
        {
            BuildPixels = new StatData() {  Current = 100,  Max = int.MaxValue };
            TechPixels = new StatData()  {  Current = 100,  Max = int.MaxValue };
            SolvePixels = new StatData() {  Current = 100,  Max = int.MaxValue };
            RawPixels = new StatData()   {  Current = 100,  Max = int.MaxValue };
            Energy = new StatData()      {  Current = 50,   Max = 100 };
        }
    }

    [Serializable]
    public class StatData
    {
        public int Current;
        public int Max;
    }
}
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts
{
    public class StatsController : MonoBehaviour
    {
        public static StatsController Inst;

        public static Stat BuildPixels;
        public static Stat TechPixels;
        public static Stat SolvePixels;
        public static Stat RawPixels;
        public static Stat Energy;

        private void Start ()
        {
            Inst = this;

            BuildPixels = new Counter(100, 0, int.MaxValue, Tags.Counter_BuildPixels.ToString());
            TechPixels = new Counter(100, 0, int.MaxValue, Tags.Counter_TechPixels.ToString());
            SolvePixels = new Counter(100, 0, int.MaxValue, Tags.Counter_SolvePixels.ToString());
            RawPixels = new Counter(100, 0, int.MaxValue, Tags.Counter_RawPixels.ToString());
            Energy = new SliderCounter(0, 0, 100, Tags.Counter_Energy.ToString());

            BuildPixels.Init();
            TechPixels.Init();
            SolvePixels.Init();
            RawPixels.Init();
            Energy.Init();
        }
    }
}
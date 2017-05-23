using Assets.Scripts.Models;
using Assets.Scripts.Models.GData;
using UnityEngine;

namespace Assets.Scripts
{
    public class StatsController : MonoBehaviour
    {
        public static StatsController Inst;

        [HideInInspector]
        public Stat BuildPixels;

        [HideInInspector]
        public Stat TechPixels;

        [HideInInspector]
        public Stat SolvePixels;

        [HideInInspector]
        public Stat RawPixels;

        [HideInInspector]
        public Stat Energy;

        private void Start ()
        {
            Inst = this;
        }

        public void Init(StatsData sd)
        {
            BuildPixels     = new Counter(          sd.BuildPixels.Current, sd.BuildPixels.Max,     Tags.Counter_BuildPixels.ToString());
            TechPixels      = new Counter(          sd.TechPixels.Current,  sd.TechPixels.Max,      Tags.Counter_TechPixels.ToString());
            SolvePixels     = new Counter(          sd.SolvePixels.Current, sd.SolvePixels.Max,     Tags.Counter_SolvePixels.ToString());
            RawPixels       = new Counter(          sd.RawPixels.Current,   sd.RawPixels.Max,       Tags.Counter_RawPixels.ToString());
            Energy          = new SliderCounter(    sd.Energy.Current,      sd.Energy.Max,          Tags.Counter_Energy.ToString());

            BuildPixels.Init();
            TechPixels.Init();
            SolvePixels.Init();
            RawPixels.Init();
            Energy.Init();
        }
    }
}
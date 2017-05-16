using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts
{
    public class StatsController : MonoBehaviour
    {
        public static StatsController Inst;

        public static Stat BuildPixels = new Counter(0, 0, int.MaxValue, Tags.Counter_BuildPixels.ToString()); 
        public static Stat TechPixels = new Counter(0, 0, int.MaxValue, Tags.Counter_TechPixels.ToString()); 
        public static Stat SolvePixels = new Counter(0, 0, int.MaxValue, Tags.Counter_SolvePixels.ToString()); 
        public static Stat RawPixels = new Counter(0, 0, int.MaxValue, Tags.Counter_RawPixels.ToString()); 

        public static Stat Energy = new SliderCounter(0, 0, 100, Tags.Counter_TechPixels.ToString());

        private void Start ()
        {
            Inst = this;
        }
    }
}
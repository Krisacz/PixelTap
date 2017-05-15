using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts
{
    public class StatsController : MonoBehaviour
    {
        public static StatsController Inst;

        public static Stat BuildPixels = new Stat(0, Tags.Counter_BuildPixels.ToString()); 
        public static Stat TechPixels = new Stat(0, Tags.Counter_TechPixels.ToString()); 
        public static Stat SolvePixels = new Stat(0, Tags.Counter_SolvePixels.ToString()); 
        public static Stat RawPixels = new Stat(0, Tags.Counter_RawPixels.ToString()); 
        
        void Start ()
        {
            Inst = this;
        }
    }
}
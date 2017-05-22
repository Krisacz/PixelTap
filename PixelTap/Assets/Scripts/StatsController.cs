using Assets.Scripts.Models;
using Assets.Scripts.Models.GData;
using UnityEngine;

namespace Assets.Scripts
{
    public class StatsController : MonoBehaviour
    {
        public static StatsController Inst;
        public StatsData Data;

        private void Start ()
        {
            Inst = this;
        }

        public void Init(StatsData statsData)
        {
            Data = statsData;
            
            Data.BuildPixels.Init();
            Data.TechPixels.Init();
            Data.SolvePixels.Init();
            Data.RawPixels.Init();
            Data.Energy.Init();
        }
    }
}
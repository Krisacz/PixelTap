using System;

namespace Assets.Scripts.Models.GData
{
    [Serializable]
    public class HqViewData : IGameScreenData
    {
        public int HqLevel;
        
        public HqViewData()
        {
            HqLevel = 0;
        }

        public bool Enabled { get; set; }
    }
}
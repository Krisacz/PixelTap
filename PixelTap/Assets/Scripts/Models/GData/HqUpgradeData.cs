using System;

namespace Assets.Scripts.Models.GData
{
    [Serializable]
    public class HqUpgradeData : IGameScreenData
    {
        public int HqUpgradeLevel;

        public HqUpgradeData()
        {
            HqUpgradeLevel = 0;
        }

        public bool Enabled { get; set; }
    }
}
using System;

namespace Assets.Scripts.Models.GData
{
    [Serializable]
    public class LabData : IGameScreenData
    {
        public int LabLevel;

        public LabData()
        {
            LabLevel = 0;
        }

        public bool Enabled { get; set; }
    }
}
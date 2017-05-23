using System;

namespace Assets.Scripts.Models.GData
{
    [Serializable]
    public class WorkshopData : IGameScreenData
    {
        public int WorkshopLevel;

        public WorkshopData()
        {
            WorkshopLevel = 0;
        }

        public bool Enabled { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Models.GData
{
    [Serializable]
    public class GameData
    {
        public StatsData StatsData;
        public GameScreenType LastCameraPosition;
        public SectorData SectorData; //TODO Potentially convert it to array of sector data object to describe whole "universe"
        
        public GameData SetDefaults()
        {
            //Stats Data
            StatsData = new StatsData();

            //Last Cam Position
            LastCameraPosition = GameScreenType.None;

            //Sector Data
            SectorData = new SectorData();

            return this;
        }
    }
}
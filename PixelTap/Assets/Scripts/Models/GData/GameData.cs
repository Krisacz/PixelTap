using System;

namespace Assets.Scripts.Models.GData
{
    [Serializable]
    public class GameData
    {
        public StatsData StatsData;
        public GameScreenType ActiveGameScreen;
        public SectorData SectorData; //TODO Potentially convert it to array of sector data object to describe whole "universe"
        
        public GameData SetDefaults()
        {
            //Stats Data
            StatsData = new StatsData();

            //Last Cam Position
            ActiveGameScreen = GameScreenType.HQView; //TODO default to NONE? 

            //Sector Data
            SectorData = new SectorData();

            return this;
        }
    }
}
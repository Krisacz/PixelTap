using System;

namespace Assets.Scripts.Models.GData
{
    [Serializable]
    public class GeneratorData : IGameScreenData
    {
        public int GeneratorLevel;

        public GeneratorData()
        {
            GeneratorLevel = 0;
        }

        public bool Enabled { get; set; }
    }
}
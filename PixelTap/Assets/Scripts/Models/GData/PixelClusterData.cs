using System;
using System.Collections.Generic;

namespace Assets.Scripts.Models.GData
{
    [Serializable]
    public class PixelClusterData : IGameScreenData
    {
        public PixelClusterType Type;
        public PixelClusterSize Size;
        public List<PixelData> Pixels;
        public float Rotation;

        public PixelClusterData()
        {
            Type = PixelClusterType.None;
            Size = PixelClusterSize.None;
            Pixels = new List<PixelData>();
            Rotation = 0f;
        }

        public bool Enabled { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Assets.Scripts.Models.GData
{
    [Serializable]
    public class ArtifactData : IGameScreenData
    {
        public ArtifactType Type;
        public ArtifactSize Size;
        public List<PixelData> Pixels;
        public float Rotation;

        public ArtifactData()
        {
            Type = ArtifactType.None;
            Size = ArtifactSize.None;
            Pixels = new List<PixelData>();
            Rotation = 0f;
        }

        public bool Enabled { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Models.GData
{
    [Serializable]
    public class PortalData : IGameScreenData
    {
        public List<DeadPixel> DeadPixels;
        public bool Encrypted;

        public PortalData()
        {
            DeadPixels = new List<DeadPixel>();
            Encrypted = false;
        }

        public bool Enabled { get; set; }
    }
}
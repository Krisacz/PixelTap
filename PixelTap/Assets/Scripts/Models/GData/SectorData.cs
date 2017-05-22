using System;

namespace Assets.Scripts.Models.GData
{
    [Serializable]
    public class SectorData
    {
        public PortalData PortalData;
        public ArtifactData ArtifactData;
        public PixelClusterData PixelClusterAlpha;
        public PixelClusterData PixelClusterBeta;
        public PixelClusterData PixelClusterGamma;

        public SectorData()
        {
            PortalData = new PortalData();
            ArtifactData = new ArtifactData();
            PixelClusterAlpha = new PixelClusterData();
            PixelClusterBeta = new PixelClusterData();
            PixelClusterGamma = new PixelClusterData();
        }
    }
}
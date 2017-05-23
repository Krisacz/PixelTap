using System;

namespace Assets.Scripts.Models.GData
{
    [Serializable]
    public class SectorData
    {
        public HqViewData HqViewData;
        public GeneratorData GeneratorData;
        public WorkshopData WorkshopData;
        public HqUpgradeData HqUpgradeData;
        public LabData LabData;

        public PortalData PortalData;
        public ArtifactData ArtifactData;
        public PixelClusterData PixelClusterAlpha;
        public PixelClusterData PixelClusterBeta;
        public PixelClusterData PixelClusterGamma;

        public SectorData()
        {
            HqViewData = new HqViewData();
            GeneratorData = new GeneratorData();
            WorkshopData = new WorkshopData();
            HqUpgradeData = new HqUpgradeData();
            LabData = new LabData();

            PortalData = new PortalData();
            ArtifactData = new ArtifactData();
            PixelClusterAlpha = new PixelClusterData();
            PixelClusterBeta = new PixelClusterData();
            PixelClusterGamma = new PixelClusterData();


            //TODO this should not be set here!!!
            HqViewData.Enabled = true;
            GeneratorData.Enabled = true;
            WorkshopData.Enabled = true;
            HqUpgradeData.Enabled = true;
            LabData.Enabled = true;

            PortalData.Enabled = true;
            ArtifactData.Enabled = true;
            PixelClusterAlpha.Enabled = true;
            PixelClusterBeta.Enabled = true;
            PixelClusterGamma.Enabled = true;
        }
    }
}
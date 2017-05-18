namespace Assets.Scripts.Models
{
    public class SectorInfo
    {
        public bool HqView { get; private set; }
        public bool Generator { get; private set; }
        public bool Workshop { get; private set; }
        public bool HqUpgrade { get; private set; }
        public bool Lab { get; private set; }
        public bool Portal { get; private set; }
        public bool Artifact { get; private set; }
        public bool PixelCluster1 { get; private set; }
        public bool PixelCluster2 { get; private set; }
        public bool PixelCluster3 { get; private set; }

        public SectorInfo(  bool hqView, bool generator, bool workshop, bool hqUpgrade, 
            bool lab, bool portal, bool artifact, bool pc1, bool pc2, bool pc3)
        {
            HqView = hqView;
            Generator = generator;
            Workshop = workshop;
            HqUpgrade = hqUpgrade;
            Lab = lab;
            Portal = portal;
            Artifact = artifact;
            PixelCluster1 = pc1;
            PixelCluster2 = pc2;
            PixelCluster3 = pc3;
        }
    }
}
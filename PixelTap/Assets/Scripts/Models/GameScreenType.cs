using System;

namespace Assets.Scripts.Models
{
    [Serializable]
    public enum GameScreenType
    {
        None,

        HQView,
        Generator,
        Workshop,
        HQUpgrade,
        Lab,

        Portal,
        Artifact,
        PixelClusterAlpha,
        PixelClusterBeta,
        PixelClusterGamma,
    }
}

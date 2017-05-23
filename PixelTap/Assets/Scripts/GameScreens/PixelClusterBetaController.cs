using Assets.Scripts.Models;
using Assets.Scripts.Models.GData;
using UnityEngine;

namespace Assets.Scripts.GameScreens
{
    public class PixelClusterBetaController : GameScreenController<PixelClusterData>
    {
        public override void Init(PixelClusterData data)
        {
            Data = data;
            //TODO use data to initialize this game screen
        }

        public override ButtonsVisibility GetButtonsVisibility()
        {
            return new ButtonsVisibility()
            {
                HQView = true,
                Generator = false,
                Workshop = false,
                HQUpgrade = false,
                Lab = false,

                Portal = true,
                Artifact = true,
                PixelCluster1 = true,
                PixelCluster2 = false,
                PixelCluster3 = true,
            };
        }
    }
}
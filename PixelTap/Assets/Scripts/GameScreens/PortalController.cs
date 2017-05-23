using Assets.Scripts.Models;
using Assets.Scripts.Models.GData;
using UnityEngine;

namespace Assets.Scripts.GameScreens
{
    public class PortalController: GameScreenController<PortalData>
    {
        public override void Init(PortalData data)
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

                Portal = false,
                Artifact = true,
                PixelCluster1 = true,
                PixelCluster2 = true,
                PixelCluster3 = true,
            };
        }
    }
}
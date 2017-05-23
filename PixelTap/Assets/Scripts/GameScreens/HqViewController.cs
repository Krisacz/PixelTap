using Assets.Scripts.Models;
using Assets.Scripts.Models.GData;
using UnityEngine;

namespace Assets.Scripts.GameScreens
{
    public class HqViewController : GameScreenController<HqViewData>
    {
        public override void Init(HqViewData data)
        {
            Data = data;
            //TODO use data to initialize this game screen
        }

        public override ButtonsVisibility GetButtonsVisibility()
        {
            return new ButtonsVisibility()
            {
                HQView = false,
                Generator = true,
                Workshop = true,
                HQUpgrade = true,
                Lab = true,

                Portal = true,
                Artifact = true,
                PixelCluster1 = true,
                PixelCluster2 = true,
                PixelCluster3 = true,
            };
        }
    }
}

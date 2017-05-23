using Assets.Scripts.Models;
using Assets.Scripts.Models.GData;
using UnityEngine;

namespace Assets.Scripts.GameScreens
{
    public class WorkshopController: GameScreenController<WorkshopData>
    {
        public override void Init(WorkshopData data)
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
                Artifact = false,
                PixelCluster1 = false,
                PixelCluster2 = false,
                PixelCluster3 = false,
            };
        }
    }
}
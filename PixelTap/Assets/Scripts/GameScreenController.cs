using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameScreenController : MonoBehaviour
    {
        public static GameScreenController Inst;
        public static GameScreenType ActiveGameScreen = GameScreenType.HQView;

        public void Start()
        {
            Inst = this;
        }

        public void MoveToPortal() { MoveToGameScreen(GameScreenType.Portal); }
        public void MoveToArtifact() { MoveToGameScreen(GameScreenType.Artifact); }
        public void MoveToPixelCluster1() { MoveToGameScreen(GameScreenType.PixelCluster1); }
        public void MoveToPixelCluster2() { MoveToGameScreen(GameScreenType.PixelCluster2); }
        public void MoveToPixelCluster3() { MoveToGameScreen(GameScreenType.PixelCluster3); }

        public void MoveToHqView() { MoveToGameScreen(GameScreenType.HQView); }
        public void MoveToGenerator() { MoveToGameScreen(GameScreenType.Generator); }
        public void MoveToWorkshop() { MoveToGameScreen(GameScreenType.Workshop); }
        public void MoveToHqUpgrade() { MoveToGameScreen(GameScreenType.HQUpgrade); }
        public void MoveToLab() { MoveToGameScreen(GameScreenType.Lab); }

        private static void MoveToGameScreen(GameScreenType gameScreen)
        {
            UIController.Inst.ButtonsRender(false);
            CameraController.MoveToGameScreen(gameScreen);
        }
    }
}

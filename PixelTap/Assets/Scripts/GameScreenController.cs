using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class GameScreenController : MonoBehaviour
    {
        public GameScreenController Inst;

        public void Start()
        {
            Inst = this;
        }

        public void MoveToPortal() { MoveToGameScreen(GameScreen.Portal); }
        public void MoveToArtifact() { MoveToGameScreen(GameScreen.Artifact); }
        public void MoveToPixelCluster1() { MoveToGameScreen(GameScreen.PixelCluster1); }
        public void MoveToPixelCluster2() { MoveToGameScreen(GameScreen.PixelCluster2); }
        public void MoveToPixelCluster3() { MoveToGameScreen(GameScreen.PixelCluster3); }

        public void MoveToHqView() { MoveToGameScreen(GameScreen.HQView); }
        public void MoveToGenerator() { MoveToGameScreen(GameScreen.Generator); }
        public void MoveToWorkshop() { MoveToGameScreen(GameScreen.Workshop); }
        public void MoveToHqUpgrade() { MoveToGameScreen(GameScreen.HQUpgrade); }
        public void MoveToLab() { MoveToGameScreen(GameScreen.Lab); }

        private static void MoveToGameScreen(GameScreen gameScreen)
        {
            UIController.Inst.ButtonsRender(false);
            CameraController.MoveToGameScreen(gameScreen);
        }
    }
}

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
        public GameScreenController Inst;

        public void Start()
        {
            Inst = this;
        }

        public void MoveToScreen(GameScreen gameScreen)
        {
            UIController.Inst.ButtonsRender(false);
            CameraController.MoveToGameScreen(gameScreen);
        }
    }
}

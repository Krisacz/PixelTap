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
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) CameraController.MoveToGameScreen(GameScreen.PixelBuilder);
            if (Input.GetKeyDown(KeyCode.Alpha2)) CameraController.MoveToGameScreen(GameScreen.PixelCluster);
            if (Input.GetKeyDown(KeyCode.Alpha3)) CameraController.MoveToGameScreen(GameScreen.HQView);
        }
    }
}

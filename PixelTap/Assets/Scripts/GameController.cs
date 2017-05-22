using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Models;
using Assets.Scripts.Models.GData;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        public GameObject GameScreensHolder;

        public GameObject HqView;
        public GameObject Generator;
        public GameObject Workshop;
        public GameObject HqUpgrade;
        public GameObject Lab;

        public GameObject Portal;
        public GameObject Artifact;
        public GameObject PixelCluster1;
        public GameObject PixelCluster2;
        public GameObject PixelCluster3;


        public void OnEnable()
        {
            //GameSave.Reset();

            //===== GAME START =====
            GameSave.Load();
            var gameData = GameSave.Get();

            //TODO Create & init basic screens
            //TODO Create & init all optional screens (conditional if they are in game data)
            //TODO Position camera
            //TODO Load and init stats
            //TODO Update current UI
        }

        private void InitGameScreens(GameData gameData)
        {
            var offset = Vector2.zero;

            Instantiate(HqView, offset, Quaternion.identity).GetComponent<GameScreen>().Init();
            Instantiate(Generator, offset, Quaternion.identity).GetComponent<GameScreen>().Init();
            //TODO.......
        }
    }
}

using System;
using System.Collections;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController: MonoBehaviour
    {
        private static GameScreen _movingTo = GameScreen.None;

        public static void MoveToGameScreen(GameScreen moveTo)
        {
            //Prevent moving from current screent to same screen
            if(GameController.ActiveGameScreen == moveTo) return;

            //From Game Screen
            var fromTag = string.Format("GameScreen_{0}", GameController.ActiveGameScreen);
            var fromGameScreen = GameObject.FindGameObjectWithTag(fromTag);
            var fromPos = fromGameScreen.transform.position;

            //To Game Screen
            var toTag = string.Format("GameScreen_{0}", moveTo);
            var toGameScreen = GameObject.FindGameObjectWithTag(toTag);
            var toPos = toGameScreen.transform.position;

            //Find point between those 2 Game Screens
            var midPoint = toPos.x > fromPos.x ? new Vector3(toPos.x, fromPos.y, -10f) : new Vector3(fromPos.x, toPos.y, -10f);
            var path = new Vector3[] {midPoint, new Vector3(toPos.x, toPos.y, -10f) };

            //Set vars
            _movingTo = moveTo;
            GameController.ActiveGameScreen = GameScreen.None;

            //Tween
            //TODO: Picked ease types: easeOutQuad, easeInCubic, easeOutQuart, easeOutQuint, easeOutExpo, easeInOutExpo, spring,
            var parms = new Hashtable();
            parms.Add("path", path);
            parms.Add("easeType", "easeInOutExpo");
            parms.Add("oncomplete", "OnCameraMoveCompleted");
            parms.Add("time", 1f);
            iTween.MoveTo(Camera.main.gameObject, parms);
        }

        public void OnCameraMoveCompleted()
        {
            GameController.ActiveGameScreen = _movingTo;
        }
    }
}

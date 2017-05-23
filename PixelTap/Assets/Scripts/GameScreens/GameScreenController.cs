using Assets.Scripts.Models;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.GameScreens
{
    public abstract class GameScreenController<T> : MonoBehaviour where T: IGameScreenData
    {
        public static GameScreenController<T> Inst;
        public static T Data;
        public void Start() { Inst = this; }
        public abstract void Init(T data);
        public abstract ButtonsVisibility GetButtonsVisibility();
        public bool IsEnabled { get; private set; }
        public void SetEnabled() { IsEnabled = Data.Enabled; }
    }
}
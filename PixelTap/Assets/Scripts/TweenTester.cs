using System;
using System.Linq;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts
{
    public class TweenTester : MonoBehaviour
    {
        public int EaseIndex = 0;
        public EaseType EaseType = EaseType.easeInCubic;

        void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            var values = Enum.GetValues(typeof(EaseType)).Cast<EaseType>().ToList();
            EaseIndex++;
            if (EaseIndex >= values.Count) EaseIndex = 0;
            EaseType = values[EaseIndex];
        }
    }
}

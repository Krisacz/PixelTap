using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class Counter : Stat
    {
        private Text _text;

        public Counter(int value, int min, int max, string tag) : base(value, min, max, tag) { }

        public override void Init()
        {
            _text = GameObject.FindGameObjectWithTag(Tag).GetComponentInChildren<Text>();
            UpdateRender();
        }

        protected sealed override void UpdateRender()
        {
            _text.text = Value.ToString("D10");
        }
    }
}
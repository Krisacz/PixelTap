using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class SliderCounter : Stat
    {
        private Slider _slider;
        private Text _text;

        public SliderCounter(int value, int max, string tag) : base(value, max, tag) { }

        public override void Init()
        {
            _slider = GameObject.FindGameObjectWithTag(Tag).GetComponentInChildren<Slider>();
            _text = GameObject.FindGameObjectWithTag(Tag).GetComponentInChildren<Text>();
            UpdateRender();
        }

        protected sealed override void UpdateRender()
        {
            _text.text = string.Format("{0} / {1}", Value, Max);
            _slider.maxValue = Max;
            _slider.minValue = Min;
            _slider.value = Value;
        }
    }
}
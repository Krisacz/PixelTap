using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Models
{
    public class SliderCounter : Stat
    {
        private Slider _slider;
        private Text _text;

        public SliderCounter(int value, int min, int max, string tag) : base(value, min, max, tag)
        {
            
        }

        public void Start()
        {
            _slider = GameObject.FindGameObjectWithTag(tag).GetComponentInChildren<Slider>();
            _text = GameObject.FindGameObjectWithTag(tag).GetComponentInChildren<Text>();
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
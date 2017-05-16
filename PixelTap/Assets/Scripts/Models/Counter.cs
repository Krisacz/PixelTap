using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Models
{
    public class Counter : Stat
    {
        private Text _text;

        public Counter(int value, int min, int max, string tag) : base(value, min, max, tag)
        {
            
        }

        public void Start()
        {
            _text = GameObject.FindGameObjectWithTag(tag).GetComponentInChildren<Text>();
        }

        protected sealed override void UpdateRender()
        {
            _text.text = Value.ToString("D10");
        }
    }
}
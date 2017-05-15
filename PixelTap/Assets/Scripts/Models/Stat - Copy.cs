using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Models
{
    public class Counter : Stat
    {
        private readonly Text _text;

        public Counter(int value, int min, int max, string tag) : base(value, min, max, tag)
        {
            _text = GameObject.FindGameObjectWithTag(tag).GetComponentInChildren<Text>();
        }

        protected sealed override void UpdateRender()
        {
            _text.text = Value.ToString("D10");
        }
    }

    public class Slider : Stat
    {
        //TODO Text?
        //TODO Slider?
        //TODO ??

        public Slider(int value, int min, int max, string tag) : base(value, min, max, tag)
        {
            _text = GameObject.FindGameObjectWithTag(tag).GetComponentInChildren<Text>();
        }

        protected sealed override void UpdateRender()
        {
            _text.text = Value.ToString("D10");
        }
    }

    public abstract class Stat : Behaviour
    {
        internal int Value;
        internal int Min;
        internal int Max;
        internal string Tag;

        public Stat(int value, int min, int max, string tag)
        {
            Value = value;
            Min = min;
            Max = max;
            Tag = tag;
        }

        protected abstract void UpdateRender();

        #region GET
        public int Get()
        {
            return Value;
        }
        #endregion

        #region SET
        public void Set(int value)
        {
            Value = value;
            UpdateRender();
        }

        public void SetMin(int value)
        {
            Min = value;
            UpdateRender();
        }

        public void SetMax(int value)
        {
            Max = value;
            UpdateRender();
        }
        #endregion

        #region CHANGE
        public void Change(int value)
        {
            Value += value;
            UpdateRender();
            if (Value < 0) Log.Error("Stat", "Tag: " + Tag, "Value after change is below 0!");
        }

        public void ChangeMin(int value)
        {
            Min += value;
            UpdateRender();
            if (Min < 0) Log.Error("Stat", "Tag: " + Tag, "Min after change is below 0!");
            if (Min > Max) Log.Error("Stat", "Tag: " + Tag, "Min after change is more than Max!");
        }

        public void ChangeMax(int value)
        {
            Max += value;
            UpdateRender();
            if (Max < 0) Log.Error("Stat", "Tag: " + Tag, "Max after change is below 0!");
            if (Max < Min) Log.Error("Stat", "Tag: " + Tag, "Max after change is less than Min!");
        }
        #endregion
    }
}
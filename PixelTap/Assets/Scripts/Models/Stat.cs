using UnityEngine;

namespace Assets.Scripts.Models
{
    public abstract class Stat : Behaviour
    {
        internal int Value;
        internal int Min;
        internal int Max;
        private readonly string _tag;

        protected Stat(int value, int min, int max, string tag)
        {
            Value = value;
            Min = min;
            Max = max;
            _tag = tag;
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
            if (Value < 0) Log.Error("Stat", "_tag: " + _tag, "Value after change is below 0!");
        }

        public void ChangeMin(int value)
        {
            Min += value;
            UpdateRender();
            if (Min < 0) Log.Error("Stat", "_tag: " + _tag, "Min after change is below 0!");
            if (Min > Max) Log.Error("Stat", "_tag: " + _tag, "Min after change is more than Max!");
        }

        public void ChangeMax(int value)
        {
            Max += value;
            UpdateRender();
            if (Max < 0) Log.Error("Stat", "_tag: " + _tag, "Max after change is below 0!");
            if (Max < Min) Log.Error("Stat", "_tag: " + _tag, "Max after change is less than Min!");
        }
        #endregion
    }
}
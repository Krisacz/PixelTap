using UnityEngine;

namespace Assets.Scripts.Models
{
    public class BuildPixel
    {
        public Vector2 Position { get; set; }
        public Color Color { get; set; }

        public BuildPixel(Vector2 position, Color color)
        {
            Position = position;
            Color = color;
        }
    }
}
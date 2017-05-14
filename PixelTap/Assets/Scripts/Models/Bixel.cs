using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Bixel : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private const float PositionOffset = 8f;
        private const float TrailOffset = 0.125f;
    
        public void Init(Color color, Vector2 position, Transform parent)
        {
            //Pixel
            transform.SetParent(parent);
            var randomOffset = GetRandomOffset();
            transform.position = position + (randomOffset * PositionOffset);
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.color = new Color(color.r, color.b, color.g, 0f);

            //Trail
            var trailRenderer = GetComponentInChildren<TrailRenderer>();
            trailRenderer.sortingLayerName = "Effects";
            trailRenderer.sortingOrder = 1;
            trailRenderer.transform.localPosition = randomOffset * TrailOffset;
            trailRenderer.colorGradient = new Gradient
                                          {
                                              alphaKeys = new[] {new GradientAlphaKey(1f, 0f), new GradientAlphaKey(0f, 1f)},
                                              colorKeys = new[] {new GradientColorKey(color, 0f), new GradientColorKey(color, 1f)}
                                          };

            //Tween - movement
            //TODO Other possible EaseTypes could be: "easeInOutQuart" or "easeInOutExpo" or "easeOutBack"
            iTween.MoveTo(gameObject, iTween.Hash("x", position.x, "y", position.y, "easeType", "easeInOutQuart", "time", 0.5f));

            //Tween - color
            var tweenParams = new Hashtable();
            tweenParams.Add("from", _spriteRenderer.color);
            tweenParams.Add("to", color);
            tweenParams.Add("time", 1f);
            tweenParams.Add("onupdate", "OnColorUpdated");
            iTween.ValueTo(gameObject, tweenParams);
        }

        public void Morph()
        {
            var c = _spriteRenderer.color;

            //Tween - color
            var tweenParams = new Hashtable();
            tweenParams.Add("from", c);
            tweenParams.Add("to", new Color(c.r, c.g, c.b, 0f));
            tweenParams.Add("time", 1f);
            tweenParams.Add("delay", 0.5f);
            tweenParams.Add("onupdate", "OnColorUpdated");
            tweenParams.Add("oncomplete", "OnMorphCompleted");
            iTween.ValueTo(gameObject, tweenParams);
        }

        private void OnColorUpdated(Color color)
        {
            _spriteRenderer.color = color;
        }

        private void OnMorphCompleted()
        {
            Destroy(gameObject);
        }

        private static Vector2 GetRandomOffset()
        {
            var rndPos = Random.Range(1, 5);
            switch (rndPos)
            {
                case 1: return new Vector2(-1f, 0f);
                case 2: return new Vector2(0f, -1f);
                case 3: return new Vector2(1f, 0f);
                case 4: return new Vector2(0f, 1f);

                default: return new Vector2(-1f, 0f);
            }
        }
    }
}
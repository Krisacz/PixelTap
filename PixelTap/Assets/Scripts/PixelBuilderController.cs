using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts
{
    public class PixelBuilderController : MonoBehaviour
    {
        public bool IsActive = false;
        public bool IsBuildRandom = true;
        public GameObject BuildPixelPrefab;

        private List<BuildPixel> _map;
        private int _currentSteps = -1;
        private bool _morphCompleted;
        private SpriteRenderer _spriteRenderer;

        void Start ()
        {
            PrepSpriteMap();
        }

        void Update ()
        {
            //Make sure we are in the correct GameScreen
            if (IsActive == false) return;

            //Prevent update if build/morph was completed
            if (_morphCompleted) return;

            //Construct pixel-by-pixel
            if (IsBuildRandom)
            {
                RandomPixel();
            }
            else
            {
                StepByStepPixel();
            }
        }
    
        private void PrepSpriteMap()
        {
            //Map sprite
            _spriteRenderer = GetComponent<SpriteRenderer>();
            var tex = _spriteRenderer.sprite.texture;
            _map = new List<BuildPixel>();

            for (var y = 0; y < tex.height; y++)
            {
                for (var x = 0; x < tex.width; x++)
                {
                    var color = tex.GetPixel(x, y);
                    if (!(color.a > 0f)) continue;
                    var cX = -(3.75f + 0.125f) + (x * 0.25f);
                    var cY = -(3.75f + 0.125f) + (y * 0.25f);
                    _map.Add(new BuildPixel(new Vector2(cX, cY), tex.GetPixel(x, y)));
                }
            }

            _currentSteps = 0;
        }

        private void RandomPixel()
        {
            if (_map.Count <= 0) return;
            if (!Inpt.Down()) return;
            var randomIndex = Random.Range(0, _map.Count);
            var pixel = _map[randomIndex];
            _map.RemoveAt(randomIndex);
            var buildPixel = Instantiate(BuildPixelPrefab, Vector3.zero, Quaternion.identity);
            buildPixel.GetComponent<Bixel>().Init(pixel.Color, pixel.Position, transform);
            if (_map.Count <= 0) Morph();
        }

        private void StepByStepPixel()
        {
            if (_currentSteps >= _map.Count) return;
            if (!Inpt.Down()) return;
            var pixel = _map[_currentSteps];
            var buildPixel = Instantiate(BuildPixelPrefab, Vector3.zero, Quaternion.identity);
            buildPixel.GetComponent<Bixel>().Init(pixel.Color, pixel.Position, transform);
            _currentSteps++;
            if (_currentSteps >= _map.Count) Morph();
        }

        private void Morph()
        {
            //Morph all pixel bits
            var allPixels = GetComponentsInChildren<Bixel>();
            foreach (var pixel in allPixels) pixel.Morph();

            //Tween - color
            var c = _spriteRenderer.color;
            var tweenParams = new Hashtable();
            tweenParams.Add("from", c);
            tweenParams.Add("to", new Color(c.r, c.g, c.b, 1f));
            tweenParams.Add("time", 1.5f);
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
            _morphCompleted = true;
        }
    }
}
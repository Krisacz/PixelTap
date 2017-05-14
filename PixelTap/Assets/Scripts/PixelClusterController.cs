using System.Collections.Generic;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts
{
    public class PixelClusterController : MonoBehaviour
    {
        public GameObject BixelPrefab;

        public Color[] ColorSet1;
        public Color[] ColorSet2;
        public Color[] ColorSet3;
        public Color[] ColorSet4;
        public Color[] ColorSet5;
        public Color[] ColorSet6;
        public Color[] ColorSet7;

        private List<GameObject> _bits;

        public void Init(int width, int height)
        {
            _bits = new List<GameObject>();
            var colorSet = GetRandomColorSet();

            var offsetX = -1f * (width * 0.25f) / 2f + 0.125f;
            var offsetY = -1f * (height * 0.25f) / 2f + 0.125f;

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    //var cX = -(3.75f + 0.125f) + (x * 0.25f);
                    //var cY = -(3.75f + 0.125f) + (y * 0.25f);

                    var cX = offsetX + (x * 0.25f);
                    var cY = offsetY + (y * 0.25f);

                    var pos = new Vector3(cX, cY, 0f);
                    var bixel = Instantiate(BixelPrefab, pos, Quaternion.identity);
                    bixel.transform.localPosition += transform.parent.position;
                    bixel.GetComponent<SpriteRenderer>().color = colorSet[Random.Range(0, colorSet.Length)];
                    bixel.transform.SetParent(transform);
                    _bits.Add(bixel);
                }
            }
        }

        void Start()
        {
            Init(8, 8);
        }

        void Update()
        {
            //Make sure we are in the correct GameScreen
            if (GameController.ActiveGameScreen != GameScreen.PixelCluster) return;
            if(_bits.Count <= 0) return;
            if (!Inpt.Down()) return;

            var randomIndex = Random.Range(0, _bits.Count);
            var bit = _bits[randomIndex];
            _bits.RemoveAt(randomIndex);
            bit.GetComponent<SpriteRenderer>().sortingOrder = 10;
            var rb = bit.AddComponent<Rigidbody2D>();
            var rX = Random.Range(-5f, 5f);
            var rY = Random.Range(-5f, 5f);
            rb.AddForce(new Vector2(rX, rY), ForceMode2D.Impulse);
        }

        private Color[] GetRandomColorSet()
        {
            var rnd = Random.Range(1, 8);
            if (rnd == 1) return ColorSet1;
            if (rnd == 2) return ColorSet2;
            if (rnd == 3) return ColorSet3;
            if (rnd == 4) return ColorSet4;
            if (rnd == 5) return ColorSet5;
            if (rnd == 6) return ColorSet6;

            return ColorSet7;
        }
    }
}

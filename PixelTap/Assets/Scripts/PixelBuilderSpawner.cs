using UnityEngine;

namespace Assets.Scripts
{
    public class PixelBuilderSpawner : MonoBehaviour
    {
        public GameObject PixelBuildPrefab;

        public Sprite DroneSprite;
        public Sprite Ship1Sprite;
        public Sprite Ship2Sprite;
        public Sprite Ship3Sprite;

        void Start ()
        {
            //Spawn();
        }

        public void Spawn()
        {
            var pixelBuild = Instantiate(PixelBuildPrefab);
            pixelBuild.GetComponent<SpriteRenderer>().sprite = GetRandom();
            pixelBuild.GetComponent<PixelBuilderController>().IsBuildRandom = true;
            pixelBuild.transform.SetParent(transform);
        }

        private Sprite GetRandom()
        {
            var rnd = Random.Range(1, 5);
            if (rnd == 1) return DroneSprite;
            if (rnd == 2) return Ship1Sprite;
            if (rnd == 3) return Ship2Sprite;

            return Ship3Sprite;
        }
    }
}

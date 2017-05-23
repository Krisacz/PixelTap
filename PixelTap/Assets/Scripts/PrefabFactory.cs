using UnityEngine;

namespace Assets.Scripts
{
    public class PrefabFactory : MonoBehaviour
    {
        public PrefabFactory Inst { get; set; }

        public GameObject HQPrefab;
        public GameObject DronePrefab;
        public GameObject DeadPixelPrefab;

        public void Start()
        {
            Inst = this;
        }

        public void Hq(Vector2 position, Transform parent)
        {
            Instantiate(HQPrefab, new Vector3(position.x, position.y, 0f), Quaternion.identity, parent);
        }

        public void Drone(Vector2 position, Transform parent)
        {
            Instantiate(DronePrefab, new Vector3(position.x, position.y, 0f), Quaternion.identity, parent);
        }

        public void DeadPixel(Vector2 position, Transform parent)
        {
            Instantiate(DeadPixelPrefab, new Vector3(position.x, position.y, 0f), Quaternion.identity, parent);
        }
    }
}

using UnityEngine;

namespace Assets.Scripts
{
    public class RotateController : MonoBehaviour
    {
        [Range(0.1f, 5f)]
        public float Speed = 1f;
        public RotationDir Direction = RotationDir.Random;
    
        void Start ()
        {
            if (Direction == RotationDir.Random) Direction = Random.Range(1, 101) > 50 ? RotationDir.Left : RotationDir.Right;
        }
	
        void Update ()
        {
            transform.Rotate(Vector3.forward, Speed * (Direction == RotationDir.Left ? 1f : -1f) );
        }

        public enum RotationDir
        {
            Random,
            Left,
            Right
        }
    }
}

using UnityEngine;

namespace ComLib.Unity.Scripts
{
    class Spin : MonoBehaviour
    {
        public Vector3 rotateSpeed;

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(rotateSpeed);
        }
    }
}

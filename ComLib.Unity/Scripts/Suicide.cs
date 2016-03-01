using UnityEngine;
using System.Collections;

namespace ComLib.Unity.Scripts
{
    /// <summary>
    /// Calls Destroy() on this.gameObject after delay
    /// </summary>
    public class Suicide : MonoBehaviour
    {
        public float delay;
        public bool killOnCollide = false;

        void Start()
        {
            Invoke("Die", delay);
        }

        void Die()
        {
            Destroy(gameObject);
        }

        void OnCollisionEnter()
        {
            if(killOnCollide)
                Destroy(gameObject);
        }
    }
}

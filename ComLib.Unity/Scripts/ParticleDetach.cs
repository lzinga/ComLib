using UnityEngine;
using System.Collections;

namespace ComLib.Unity.Scripts
{
    /// <summary>
    /// Attach this script to a ParticleSystem, and then when you want it to persist, call Detach() on it.
    /// 
    /// <para></para>This will also automatically kill the particle effect when the last particle has died
    /// Because of this, if you let it continue emitting, it will persist forever. You will have to manually stop/kill it
    /// This is best used for things that explode/die but leave behind something like a smoke trail</para>
    /// </summary>
    public class DetachParticle : MonoBehaviour
    {
        ParticleSystem particle;
        public bool detachOnWake;
        public bool StopEmission;

        private bool detached = false;

        // Use this for initialization
        IEnumerator Start()
        {
            particle = GetComponent<ParticleSystem>();

            if (!particle)
                Debug.LogError("DetachParticle didn't find a particle system on this gameobject!");
            else
                //Debug.Log("DetachParticle found " + particle.name);

            yield return new WaitForEndOfFrame();

            if (detachOnWake)
                Detach();
        }

        // Update is called once per frame
        void Update()
        {
            if (detached && particle.particleCount <= 0)
                Destroy(gameObject);
        }


        public void Detach()
        {
            //Debug.Log("Detaching " + particle.name);

            if (StopEmission)
                particle.emissionRate = 0;

            detached = true;

            // This splits the particle off so it doesn't get deleted with the parent
            gameObject.transform.parent = null;
        }
    }
}

using UnityEngine;
using System.Collections;

namespace ComLib.Unity.Extensions
{

    /// <summary>
    /// Particle Extentions for unity 5.
    /// </summary>
    public static class ParticleExtensions
    {

        /// <summary>
        /// Enables a particle emission for a set amount of time and then disables it. No update needed this is using a IEnumerator with a WaitForSeconds timer.
        /// </summary>
        /// <param name="particleSystem"></param>
        /// <param name="timer"></param>
        /// <param name="particleAmount"></param>
        /// <returns></returns>
        public static IEnumerator EnableTimedEmission(this ParticleSystem particleSystem, float timer, float particleAmount)
        {
            SetEmissionRate(particleSystem, 100f);
            yield return new WaitForSeconds(timer);
            SetEmissionRate(particleSystem, 0f);
        }

        /// <summary>
        /// Enable selected particle system emission. This is needed because you cannot access emission directly.
        /// </summary>
        /// <param name="particleSystem"></param>
        /// <param name="enabled"></param>
        public static void EnableEmission(this ParticleSystem particleSystem, bool enabled)
        {
            var emission = particleSystem.emission;
            emission.enabled = enabled;
        }

        /// <summary>
        /// Get current emission rate of selected particle system. This is needed because you cannot access emission directly.
        /// </summary>
        /// <param name="particleSystem"></param>
        /// <returns></returns>
        public static float GetEmissionRate(this ParticleSystem particleSystem)
        {
            return particleSystem.emission.rate.constantMax;
        }

        /// <summary>
        /// set current emission rate of selected particle system. This is needed because you cannot access emission directly.
        /// </summary>
        /// <param name="particleSystem"></param>
        /// <param name="emissionRate"></param>
        public static void SetEmissionRate(this ParticleSystem particleSystem, float emissionRate)
        {
            var emission = particleSystem.emission;
            var rate = emission.rate;
            rate.constantMax = emissionRate;
            emission.rate = rate;
        }
    }
}

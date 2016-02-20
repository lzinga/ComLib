using UnityEngine;
using System.Collections;
using ComLib.Unity.Extensions;

namespace ComLib.Unity.Scripts
{
    /// <summary>
    /// Holds a number of audio clips to randomly play in the attached audioSource
    /// </summary>
    public class AudioCollection : MonoBehaviour
    {

        public AudioClip[] audioClips;
        public bool useRandomPitch;
        public Vector2 pitchRange;

        public AudioSource audioSource;

        // Use this for initialization
        void Start()
        {
            if (!audioSource)
            {
                audioSource = GetComponent<AudioSource>();
            }
        }

        public void PlayRandomClip()
        {
            audioSource.pitch = Random.Range(pitchRange.x, pitchRange.y);
            audioSource.PlayOneShot(audioClips.GetRandom());
        }
    }
}

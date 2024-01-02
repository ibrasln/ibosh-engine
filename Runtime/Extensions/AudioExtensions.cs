using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IboshEngine.Runtime.Extensions
{
    public static class AudioExtensions
    {
        public static void PlayRandomAudio(this AudioSource audioSource, AudioClip[] audioClips)
        {
            if (audioClips.Length > 0)
            {
                int randomIndex = Random.Range(0, audioClips.Length);
                audioSource.PlayOneShot(audioClips[randomIndex]);
            }
        }
    }
}

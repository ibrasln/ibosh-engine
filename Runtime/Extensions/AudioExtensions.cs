using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IboshEngine.Runtime.Extensions
{
    /// <summary>
    /// Extension methods for AudioSource in Unity, providing additional functionality for playing random audio clips.
    /// </summary>
    /// <remarks>
    /// The class includes an extension method that allows playing a random AudioClip from a provided array of audio clips using the specified AudioSource.
    /// </remarks>
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

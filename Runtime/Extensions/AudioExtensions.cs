using System.Collections;
using System.Collections.Generic;
using IboshEngine.Runtime.Debugger;
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
        /// <summary>
        /// Extension method to play a random AudioClip from the provided array.
        /// </summary>
        /// <param name="audioSource">The AudioSource to play the audio clip.</param>
        /// <param name="audioClips">An array of AudioClip options to choose from.</param>
        public static void PlayRandomAudio(this AudioSource audioSource, AudioClip[] audioClips)
        {
            if (audioClips.IsNullOrEmpty())
            {
                IboshDebugger.LogError($"Audio clips array is null or empty!", audioSource.name, IboshDebugger.DebugColor.Gray, IboshDebugger.DebugColor.Red);
                return;
            }
            
            int randomIndex = Random.Range(0, audioClips.Length);
            audioSource.PlayOneShot(audioClips[randomIndex]);
        }
    }
}

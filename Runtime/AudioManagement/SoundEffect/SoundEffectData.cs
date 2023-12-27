using UnityEngine;

namespace IboshEngine.Runtime.AudioManagement
{
    [CreateAssetMenu(fileName = "SoundEffectData_", menuName = "Data/Audio/Sound Effect Data")]
    public class SoundEffectData : ScriptableObject
    {
        public string Name;
        public AudioClip Clip;
        [Range(0, 1)] public float Volume = 1;
        [Range(.1f, 1.5f)] public float MinPitch = 1;
        [Range(.1f, 1.5f)] public float MaxPitch = 1;

        public float Pitch { get => Random.Range(MinPitch, MaxPitch); }
        public float Length { get => Clip.length; }
    }
}
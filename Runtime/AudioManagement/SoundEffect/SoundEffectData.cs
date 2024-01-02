using NaughtyAttributes;
using UnityEngine;

namespace IboshEngine.Runtime.AudioManagement
{
    [CreateAssetMenu(fileName = "SoundEffectData_", menuName = "Data/Audio/Sound Effect Data")]
    public class SoundEffectData : ScriptableObject
    {
        public string Name;
        public AudioClip Clip;
        [Range(0, 1)] public float Volume = 1;
        public bool IsPitchRandom;
        [ShowIf("IsPitchRandom")][Range(.1f, 1.5f)] public float MinPitch = .8f;
        [ShowIf("IsPitchRandom")][Range(.1f, 1.5f)] public float MaxPitch = 1.2f;

        public float Pitch
        {
            get
            {
                if (IsPitchRandom) return Random.Range(MinPitch, MaxPitch);
                return 1;
            }
                
        }
        public float Length => Clip.length;
    }
}
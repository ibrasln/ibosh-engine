using UnityEngine;

namespace IboshEngine.Runtime.AudioManagement
{
    public class SoundEffect : MonoBehaviour
    {
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }

        private void OnDisable()
        {
            audioSource.Stop();
        }

        public void SetSound(SoundEffectData soundEffect)
        {
            audioSource.pitch = soundEffect.Pitch;
            audioSource.volume = soundEffect.Volume;
            audioSource.clip = soundEffect.Clip;
        }
    }
}
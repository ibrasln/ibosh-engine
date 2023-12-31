using UnityEngine;

namespace IboshEngine.Runtime.AudioManagement
{
    public class SoundEffect : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            if (_audioSource != null)
            {
                _audioSource.Play();
            }
        }

        private void OnDisable()
        {
            _audioSource.Stop();
        }

        public void SetSound(SoundEffectData soundEffect)
        {
            _audioSource.pitch = soundEffect.Pitch;
            _audioSource.volume = soundEffect.Volume;
            _audioSource.clip = soundEffect.Clip;
        }
    }
}
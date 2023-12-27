using IboshEngine.Runtime.ObjectPool;
using IboshEngine.Runtime.Singleton;
using IboshEngine.Runtime.Utilities;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace IboshEngine.Runtime.AudioManagement
{
    public class SoundEffectManager : IboshSingleton<SoundEffectManager>
    {
        private ObjectPool<SoundEffect> _soundEffectPool;
        [SerializeField] private GameObject soundEffectPrefab;
        [SerializeField] private AudioMixerGroup soundEffectsMasterMixerGroup;
        private int _soundEffectsVolume;

        protected override void Awake()
        {
            base.Awake();
            _soundEffectPool = new(soundEffectPrefab, transform, 15);
        }

        private void Start()
        {
            if (PlayerPrefs.HasKey("SoundEffectsVolume"))
            {
                _soundEffectsVolume = PlayerPrefs.GetInt("SoundEffectsVolume");
            }

            SetVolume(_soundEffectsVolume);
        }

        private void OnDisable()
        {
            PlayerPrefs.SetInt("SoundEffectsVolume", _soundEffectsVolume);
        }

        public void Play(SoundEffectData soundEffect)
        {
            SoundEffect sound = _soundEffectPool.Pull();
            sound.gameObject.SetActive(true);
            sound.SetSound(soundEffect);
            StartCoroutine(DisableSoundEffect(sound, soundEffect.Length));
        }

        private IEnumerator DisableSoundEffect(SoundEffect sound, float soundDuration)
        {
            yield return new WaitForSeconds(soundDuration);
            _soundEffectPool.Push(sound.gameObject);
        }

        public void IncreaseVolume()
        {
            int maxSoundVolume = 20;

            if (_soundEffectsVolume >= maxSoundVolume) return;

            _soundEffectsVolume++;

            SetVolume(_soundEffectsVolume);
        }

        public void DecreaseVolume()
        {
            if (_soundEffectsVolume == 0) return;

            _soundEffectsVolume--;

            SetVolume(_soundEffectsVolume);
        }

        private void SetVolume(int soundEffectsVolume)
        {
            float muteDecibels = -80f;

            if (soundEffectsVolume == 0)
            {
                soundEffectsMasterMixerGroup.audioMixer.SetFloat("SoundEffectsVolume", muteDecibels);
            }
            else
            {
                soundEffectsMasterMixerGroup.audioMixer.SetFloat("SoundEffectsVolume", ConversionUtilities.LinearToDecibels(soundEffectsVolume));
            }
        }
    }
}
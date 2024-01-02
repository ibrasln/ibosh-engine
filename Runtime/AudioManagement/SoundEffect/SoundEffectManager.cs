using System;
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
        public Action OnSoundPlayed;
        
        private ObjectPool<SoundEffect> _soundEffectPool;
        [SerializeField] private GameObject soundEffectPrefab;
        [SerializeField] private AudioMixerGroup soundEffectsMasterMixerGroup;
        private int _soundEffectVolume;

        protected override void Awake()
        {
            base.Awake();
            _soundEffectPool = new(soundEffectPrefab, transform, 15);
        }

        private void Start()
        {
            if (PlayerPrefs.HasKey("SoundEffectsVolume"))
            {
                _soundEffectVolume = PlayerPrefs.GetInt("SoundEffectsVolume");
            }

            SetVolume(_soundEffectVolume);
        }

        private void OnDisable()
        {
            PlayerPrefs.SetInt("SoundEffectsVolume", _soundEffectVolume);
        }

        public void Play(SoundEffectData soundEffect)
        {
            SoundEffect sound = _soundEffectPool.Pull();
            sound.gameObject.SetActive(true);
            sound.SetSound(soundEffect);
            OnSoundPlayed?.Invoke();
            StartCoroutine(DisableSoundEffect(sound, soundEffect.Length));
        }

        private IEnumerator DisableSoundEffect(SoundEffect sound, float soundDuration)
        {
            yield return new WaitForSeconds(soundDuration);
            _soundEffectPool.Push(sound.gameObject);
        }

        public void IncreaseVolume()
        {
            const int maxSoundVolume = 20;

            if (_soundEffectVolume >= maxSoundVolume) return;

            _soundEffectVolume++;

            SetVolume(_soundEffectVolume);
        }

        public void DecreaseVolume()
        {
            if (_soundEffectVolume == 0) return;

            _soundEffectVolume--;

            SetVolume(_soundEffectVolume);
        }

        private void SetVolume(int soundEffectsVolume)
        {
            const float muteDecibels = -80f;

            soundEffectsMasterMixerGroup.audioMixer.SetFloat("SoundEffectsVolume",
                soundEffectsVolume == 0 ? muteDecibels : ConversionUtilities.LinearToDecibels(soundEffectsVolume));
        }
    }
}
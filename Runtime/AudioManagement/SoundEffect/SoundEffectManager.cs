using System;
using IboshEngine.Runtime.ObjectPool;
using IboshEngine.Runtime.Singleton;
using IboshEngine.Runtime.Utilities;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

namespace IboshEngine.Runtime.AudioManagement
{
    public class SoundEffectManager : IboshSingleton<SoundEffectManager>
    {
        public Action OnSoundPlayed;
        
        private ObjectPool<SoundEffect> _soundEffectPool;
        [SerializeField] private GameObject soundEffectPrefab;
        [SerializeField] private AudioMixerGroup soundEffectsMasterMixerGroup;
        [ReadOnly] public int SoundEffectVolume = 10;

        protected override void Awake()
        {
            base.Awake();
            _soundEffectPool = new(soundEffectPrefab, transform, 15);
        }

        private void Start()
        {
            if (PlayerPrefs.HasKey("SoundEffectVolume"))
            {
                SoundEffectVolume = PlayerPrefs.GetInt("SoundEffectVolume");
            }

            SetVolume(SoundEffectVolume);
        }

        private void OnDisable()
        {
            PlayerPrefs.SetInt("SoundEffectVolume", SoundEffectVolume);
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

            if (SoundEffectVolume >= maxSoundVolume) return;

            SoundEffectVolume++;

            SetVolume(SoundEffectVolume);
        }

        public void DecreaseVolume()
        {
            if (SoundEffectVolume == 0) return;

            SoundEffectVolume--;

            SetVolume(SoundEffectVolume);
        }

        private void SetVolume(int soundEffectVolume)
        {
            const float muteDecibels = -80f;

            soundEffectsMasterMixerGroup.audioMixer.SetFloat("SoundEffectVolume",
                soundEffectVolume == 0 ? muteDecibels : ConversionUtilities.LinearToDecibels(soundEffectVolume));
        }
    }
}
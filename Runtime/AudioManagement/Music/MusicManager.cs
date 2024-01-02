using System;
using IboshEngine.Runtime.Singleton;
using UnityEngine;
using System.Collections;
using IboshEngine.Runtime.Utilities;
using NaughtyAttributes;
using UnityEngine.Audio;
using UnityEngine.Serialization;

namespace IboshEngine.Runtime.AudioManagement
{
    public class MusicManager : IboshSingleton<MusicManager>
    {
        public Action OnMusicStarted;
        public Action OnMusicStopped;
        
        #region Audio Mixer
        [SerializeField] private AudioMixerGroup musicMasterMixerGroup;
        [SerializeField] private AudioMixerSnapshot musicOnFullSnapshot;
        [SerializeField] private AudioMixerSnapshot musicLowSnapshot;
        [SerializeField] private AudioMixerSnapshot musicOffSnapshot;
        #endregion
        
        private const float MusicFadeInTime = .75f;
        private const float MusicFadeOutTime = .75f;

        private AudioSource _audioSource;
        private AudioClip _currentMusic;
        private Coroutine _fadeOutMusicCoroutine;
        private Coroutine _fadeInMusicCoroutine;
        [ReadOnly] public int MusicVolume = 10;

        protected override void Awake()
        {
            base.Awake();

            _audioSource = GetComponent<AudioSource>();

            musicOffSnapshot.TransitionTo(0f);
        }

        private void Start()
        {
            if (PlayerPrefs.HasKey("MusicVolume"))
            {
                MusicVolume = PlayerPrefs.GetInt("MusicVolume");
            }

            SetVolume(MusicVolume);
        }

        private void OnDisable()
        {
            PlayerPrefs.SetInt("MusicVolume", MusicVolume);
        }

        public void Play(MusicData musicTrack, float fadeOutTime = MusicFadeOutTime, float fadeInTime = MusicFadeInTime)
        {
            StartCoroutine(PlayRoutine(musicTrack, fadeOutTime, fadeInTime));
        }

        private IEnumerator PlayRoutine(MusicData musicTrack, float fadeOutTime, float fadeInTime)
        {
            if (_fadeOutMusicCoroutine != null)
            {
                StopCoroutine(_fadeOutMusicCoroutine);
            }

            if (_fadeInMusicCoroutine != null)
            {
                StopCoroutine(_fadeInMusicCoroutine);
            }

            if (musicTrack.Clip != _currentMusic)
            {
                _currentMusic = musicTrack.Clip;

                yield return _fadeOutMusicCoroutine = StartCoroutine(FadeOut(fadeOutTime));

                yield return _fadeInMusicCoroutine = StartCoroutine(FadeIn(musicTrack, fadeInTime));
            }

            yield return null;
        }

        private IEnumerator FadeOut(float fadeOutTime)
        {
            musicLowSnapshot.TransitionTo(fadeOutTime);

            yield return new WaitForSeconds(fadeOutTime);
            OnMusicStopped?.Invoke();
        }

        private IEnumerator FadeIn(MusicData musicTrack, float fadeInTime)
        {
            _audioSource.clip = musicTrack.Clip;
            _audioSource.volume = musicTrack.Volume;
            _audioSource.Play();

            musicOnFullSnapshot.TransitionTo(fadeInTime);

            OnMusicStarted?.Invoke();
            
            yield return new WaitForSeconds(fadeInTime);
        }

        public void IncreaseVolume()
        {
            int maxMusicVolume = 20;

            if (MusicVolume >= maxMusicVolume) return;

            MusicVolume++;

            SetVolume(MusicVolume);    
        }

        public void DecreaseVolume()
        {
            if (MusicVolume == 0) return;

            MusicVolume--;

            SetVolume(MusicVolume);
        }

        private void SetVolume(float musicVolume)
        {
            const float muteDecibels = -80f;

            musicMasterMixerGroup.audioMixer.SetFloat("MusicVolume",
                musicVolume == 0 ? muteDecibels : ConversionUtilities.LinearToDecibels(musicVolume));
        }
    }
}

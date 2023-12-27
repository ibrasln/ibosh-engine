using IboshEngine.Runtime.Singleton;
using UnityEngine;
using System.Collections;
using IboshEngine.Runtime.Utilities;
using UnityEngine.Audio;
namespace IboshEngine.Runtime.AudioManagement
{
    public class MusicManager : IboshSingleton<MusicManager>
    {
        [SerializeField] private AudioMixerGroup musicMasterMixerGroup;
        [SerializeField] private AudioMixerSnapshot musicOnFullSnapshot;
        [SerializeField] private AudioMixerSnapshot musicLowSnapshot;
        [SerializeField] private AudioMixerSnapshot musicOffSnapshot;
        [SerializeField] private float musicFadeInTime = .5f;
        [SerializeField] private float musicFadeOutTime = .5f;

        private AudioSource audioSource;
        private AudioClip currentMusic;
        private Coroutine fadeOutMusicCoroutine;
        private Coroutine fadeInMusicCoroutine;
        public int _musicVolume = 10;

        protected override void Awake()
        {
            base.Awake();

            audioSource = GetComponent<AudioSource>();

            musicOffSnapshot.TransitionTo(0f);
        }

        private void Start()
        {
            if (PlayerPrefs.HasKey("MusicVolume"))
            {
                _musicVolume = PlayerPrefs.GetInt("MusicVolume");
            }

            SetVolume(_musicVolume);
        }

        private void OnDisable()
        {
            PlayerPrefs.SetInt("MusicVolume", _musicVolume);
        }

        public void Play(MusicData musicTrack, float fadeOutTime = .5f, float fadeInTime = .5f)
        {
            StartCoroutine(PlayRoutine(musicTrack, fadeOutTime, fadeInTime));
        }

        private IEnumerator PlayRoutine(MusicData musicTrack, float fadeOutTime, float fadeInTime)
        {
            if (fadeOutMusicCoroutine != null)
            {
                StopCoroutine(fadeOutMusicCoroutine);
            }

            if (fadeInMusicCoroutine != null)
            {
                StopCoroutine(fadeInMusicCoroutine);
            }

            if (musicTrack.Clip != currentMusic)
            {
                currentMusic = musicTrack.Clip;

                yield return fadeOutMusicCoroutine = StartCoroutine(FadeOut(fadeOutTime));

                yield return fadeInMusicCoroutine = StartCoroutine(FadeIn(musicTrack, fadeInTime));
            }

            yield return null;
        }

        private IEnumerator FadeOut(float fadeOutTime)
        {
            musicLowSnapshot.TransitionTo(fadeOutTime);

            yield return new WaitForSeconds(fadeOutTime);
        }

        private IEnumerator FadeIn(MusicData musicTrack, float fadeInTime)
        {
            audioSource.clip = musicTrack.Clip;
            audioSource.volume = musicTrack.Volume;
            audioSource.Play();

            musicOnFullSnapshot.TransitionTo(fadeInTime);

            yield return new WaitForSeconds(fadeInTime);
        }

        public void IncreaseVolume()
        {
            int maxMusicVolume = 20;

            if (_musicVolume >= maxMusicVolume) return;

            _musicVolume++;

            SetVolume(_musicVolume);    
        }

        public void DecreaseVolume()
        {
            if (_musicVolume == 0) return;

            _musicVolume--;

            SetVolume(_musicVolume);
        }

        public void SetVolume(float musicVolume)
        {
            float muteDecibels = -80f;

            if (musicVolume == 0)
            {
                musicMasterMixerGroup.audioMixer.SetFloat("MusicVolume", muteDecibels);
            }
            else
            {
                musicMasterMixerGroup.audioMixer.SetFloat("MusicVolume", ConversionUtilities.LinearToDecibels(musicVolume));
            }
        }
    }
}

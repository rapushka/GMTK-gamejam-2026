using System.Diagnostics;
using UnityEngine;
using UnityEngine.Audio;
using Debug = UnityEngine.Debug;

namespace Core
{
    public class AudioPlayer : MonoBehaviour, IService
    {
        [Header("Music")]
        [SerializeField] private AudioSource _mainMenuMusic;
        [SerializeField] private AudioSource _gameplayMusic;

        [Header("SFX")]
        [SerializeField] private SoundsCollection _soundsCollection;
        [SerializeField] private SfxPool _sfxPool;

        [Header("Settings")]
        [SerializeField] private AudioMixerGroup _audioMixer;

        private MusicMixin _musicMixin;

        // TODO: Settings
        public float MusicVolume  { set => _audioMixer.audioMixer.SetFloat("MusicVolume", value); }
        public float MasterVolume { set => _audioMixer.audioMixer.SetFloat("MasterVolume", value); }
        public float SfxVolume    { set => _audioMixer.audioMixer.SetFloat("SfxVolume", value); }

        public void Init()
        {
            // TODO: check sounds/music volume

            _musicMixin = new(_mainMenuMusic, _gameplayMusic);
            _sfxPool.Init();
            _soundsCollection.Init();
        }

        public void PlayMusicMainMenu() => _musicMixin.PlayMainMenu();
        public void PlayMusicGameplay() => _musicMixin.PlayGameplay();

        public void PlaySound(string key, FloatRange? volume = null, FloatRange? pitchRange = null)
        {
            var audioClip = _soundsCollection.Get(key);

            _sfxPool.Play(audioClip, volume, pitchRange);
        }
    }
}
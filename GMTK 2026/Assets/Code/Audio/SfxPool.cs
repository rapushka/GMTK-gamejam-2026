using UnityEngine;

namespace Core
{
    public class SfxPool : MonoBehaviour
    {
        private const int PoolSize = 16;

        private AudioSource[] _sources;
        private int _nextIndex;

        public void Init()
        {
            _sources = new AudioSource[PoolSize];

            for (var i = 0; i < _sources.Length; i++)
            {
                var sourceGo = new GameObject($"SFX Source - {i}");
                sourceGo.transform.SetParent(transform);

                var audioSource = sourceGo.AddComponent<AudioSource>();
                audioSource.playOnAwake = false;

                _sources[i] = audioSource;
            }
        }

        public void Play(AudioClip clip, FloatRange? volumeRange = null, FloatRange? pitchRange = null)
        {
            var audioSource = _sources[_nextIndex];
            _nextIndex = (_nextIndex + 1) % _sources.Length;

            audioSource.pitch = pitchRange?.GetRandom() ?? 1f;

            var volume = volumeRange?.GetRandom() ?? 1f;
            audioSource.PlayOneShot(clip, volume);
        }
    }
}
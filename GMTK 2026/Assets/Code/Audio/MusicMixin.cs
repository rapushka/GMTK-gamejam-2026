using DG.Tweening;
using UnityEngine;

namespace Core
{
    public class MusicMixin
    {
        private readonly AudioSource _mainMenuMusic;
        private readonly AudioSource _gameplayMusic;

        private const float CrossfadeDuration = 1f;

        private Tween _tweenFrom;
        private Tween _tweenTo;

        public MusicMixin(AudioSource mainMenuMusic, AudioSource gameplayMusic)
        {
            _mainMenuMusic = mainMenuMusic;
            _gameplayMusic = gameplayMusic;
        }

        public void PlayMainMenu() => Crossfade(from: _gameplayMusic, to: _mainMenuMusic);
        public void PlayGameplay() => Crossfade(from: _mainMenuMusic, to: _gameplayMusic);

        private void Crossfade(AudioSource from, AudioSource to)
        {
            _tweenFrom?.Kill();
            _tweenTo?.Kill();

            to.volume = 0f;

            if (!to.isPlaying)
                to.Play();

            _tweenFrom = from.DOFade(0f, CrossfadeDuration)
                .SetUpdate(true)
                .OnComplete(from.Stop);

            _tweenTo = to.DOFade(1f, CrossfadeDuration)
                .SetUpdate(true);
        }
    }
}
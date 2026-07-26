using DG.Tweening;
using UnityEngine;

namespace Core
{
    public class ItemPreviewContainer : MonoBehaviour, IService
    {
        [SerializeField] private SpriteRenderer _background;
        [SerializeField] private float _targetFade = 0.8f;

        private Tween _tween;

        public void Show()
        {
            _tween?.Kill();

            _tween = _background.DOFade(_targetFade, 0.3f)
                .SetEase(Ease.InOutSine)
                .Play();
        }

        public void Hide()
        {
            _tween?.Kill();

            _tween = _background.DOFade(0, 0.3f)
                .SetEase(Ease.InOutSine)
                .Play();
        }
    }
}
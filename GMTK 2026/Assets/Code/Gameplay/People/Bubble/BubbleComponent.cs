using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Core
{
    public class BubbleComponent : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _itemIcon;

        [SerializeField] private float _appearScaleDuration = 0.3f;
        [SerializeField] private float _iconFadeDuration = 0.25f;
        [SerializeField] private float _thinkDuration = 0.8f;
        [SerializeField] private float _disappearDuration = 0.2f;

        public async UniTask Appear(Sprite itemSprite)
        {
            transform.localScale = Vector3.zero;

            _itemIcon.sprite = itemSprite;
            SetIconAlpha(0f);

            await transform.DOScale(1f, _appearScaleDuration)
                .SetEase(Ease.OutBack)
                .ToUniTask();

            await _itemIcon.DOFade(1f, _iconFadeDuration)
                .ToUniTask();

            await UniTask.WaitForSeconds(_thinkDuration);
        }

        public async UniTask Disappear()
        {
            await transform.DOScale(0f, _disappearDuration)
                .SetEase(Ease.InBack)
                .ToUniTask();

            Destroy(gameObject);
        }

        private void SetIconAlpha(float alpha)
        {
            var color = _itemIcon.color;
            color.a = alpha;
            _itemIcon.color = color;
        }
    }
}

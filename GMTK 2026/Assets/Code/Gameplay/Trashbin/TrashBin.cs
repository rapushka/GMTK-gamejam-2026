using UnityEngine;

namespace Core
{
    public class TrashBin : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private Sprite _openSprite;
        [SerializeField] private Sprite _closedSprite;

        private Collider2D _collider;

        private Collider2D Collider => _collider ??= GetComponent<Collider2D>();

        private void Awake()
        {
            SetOpen(false);
        }

        public bool IsInBounds(Vector2 worldPoint)
        {
            return Collider.OverlapPoint(worldPoint);
        }

        public void SetOpen(bool open)
        {
            _spriteRenderer.sprite = open ? _openSprite : _closedSprite;
        }
    }
}
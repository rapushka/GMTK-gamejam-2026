using UnityEngine;

namespace Core
{
    public class SingleLifeUI : MonoBehaviour
    {
        [SerializeField] private Sprite _normal;
        [SerializeField] private Sprite _lost;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public bool IsFull { get; private set; }

        public void Init()
        {
            _spriteRenderer.sprite = _normal;
            IsFull = true;
        }

        public void Loose()
        {
            _spriteRenderer.sprite = _lost;
            IsFull = false;
        }
    }
}
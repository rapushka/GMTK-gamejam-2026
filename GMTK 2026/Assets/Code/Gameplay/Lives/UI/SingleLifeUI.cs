using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class SingleLifeUI : MonoBehaviour
    {
        [SerializeField] private Sprite _normal;
        [SerializeField] private Sprite _lost;
        [SerializeField] private Image _imageRenderer;

        public bool IsFull { get; private set; }

        public void Init()
        {
            _imageRenderer.sprite = _normal;
            IsFull = true;
        }

        public void Loose()
        {
            _imageRenderer.sprite = _lost;
            IsFull = false;
        }
    }
}
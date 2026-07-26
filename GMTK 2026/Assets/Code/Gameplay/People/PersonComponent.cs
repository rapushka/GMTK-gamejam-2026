using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core
{
    public class PersonComponent : MonoBehaviour
    {
        [SerializeField] private Animation _animations;
        [field: SerializeField] public Transform BubblePivot { get; private set; }

        public void Init()
        {
            gameObject.SetActive(false);
        }

        public async UniTask Appear()
        {
            gameObject.SetActive(true);
            _animations.Play("PersonAppear");
            await UniTask.WaitUntil(() => !_animations.isPlaying);

            _animations.Play("PersonIdle");
        }

        public async UniTask Hide()
        {
            _animations.Play("PersonDisappear");
            await UniTask.WaitUntil(() => !_animations.isPlaying);
            gameObject.SetActive(false);
        }
    }
}
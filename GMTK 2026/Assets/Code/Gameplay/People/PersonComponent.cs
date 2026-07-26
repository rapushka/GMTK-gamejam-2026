using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core
{
    public class PersonComponent : MonoBehaviour
    {
        [SerializeField] private Animation _appearAnimation;

        public void Init()
        {
            gameObject.SetActive(false);
        }

        public async UniTask Appear()
        {
            gameObject.SetActive(true);
            _appearAnimation.Play("PersonAppear");
            await UniTask.WaitUntil(() => !_appearAnimation.isPlaying);

            _appearAnimation.Play("PersonIdle");
        }

        public async UniTask Hide()
        {
            _appearAnimation.Play("PersonDisappear");
            await UniTask.WaitUntil(() => !_appearAnimation.isPlaying);
            gameObject.SetActive(false);
        }
    }
}
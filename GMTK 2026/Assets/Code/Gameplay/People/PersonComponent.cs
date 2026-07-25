using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core
{
    public class PersonComponent : MonoBehaviour
    {
        [SerializeField] private Animation _appearAnimation;

        public void Init() { }

        public async UniTask Appear()
        {
            // var animation = GetComponent<Animation>();
            // animation.Play();
            // animation.Play("PersonAppear");
            _appearAnimation.Play();
            gameObject.SetActive(true);
            await UniTask.WaitUntil(() => !_appearAnimation.isPlaying);
        }
    }
}
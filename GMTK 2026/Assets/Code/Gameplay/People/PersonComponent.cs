using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core
{
    public class PersonComponent : MonoBehaviour
    {
        public void Init() { }

        public UniTask Appear()
        {
            return UniTask.CompletedTask;
        }
    }
}
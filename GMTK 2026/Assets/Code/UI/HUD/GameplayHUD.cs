using UnityEngine;

namespace Core
{
    public class GameplayHUD : MonoBehaviour
    {
        [field: SerializeField] public LivesCounterUI LivesCounter { get; private set; }
    }
}
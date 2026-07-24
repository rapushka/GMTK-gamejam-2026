using UnityEngine;

namespace Core
{
    public class GameScreen : MonoBehaviour
    {
        [SerializeField] private Fridge _fridge;

        public Fridge Fridge => _fridge;
    }
}
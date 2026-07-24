using UnityEngine;

namespace Core
{
    public class GameScreen : MonoBehaviour
    {
        [SerializeField] private Fridge _fridge;
        [SerializeField] private TrashBin _trashBin;

        public Fridge   Fridge   => _fridge;
        public TrashBin TrashBin => _trashBin;
    }
}
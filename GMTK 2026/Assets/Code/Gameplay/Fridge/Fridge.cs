using UnityEngine;

namespace Core
{
    public class Fridge : MonoBehaviour
    {
        [SerializeField] private Shelf[] _shelves;

        public Shelf[] Shelves => _shelves;
    }
}
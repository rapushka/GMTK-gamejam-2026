using UnityEngine;

namespace Core
{
    public class HandWithBagComponent : PersonComponent
    {
        [field: SerializeField] public Transform FoodOrigin { get; private set; }
    }
}
using System;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class BalanceConfig : IService
    {
        [field: SerializeField] public float HourTickIntervalS { get; private set; } = 1f;

        [field: SerializeField] public int LifesCount { get; private set; } = 3;

        [field: Header("People")]
        [field: SerializeField] public FloatRange PeopleArriveS { get; private set; } = new(5f, 15f);

        [field: Tooltip("How Many Food Can Left in Fridge before People will go for new Items")]
        [field: SerializeField] public int MinFoodInFridgeToBuyNewBatch { get; private set; } = 3;

        [field: Header("Fridge")]
        [field: SerializeField] public IntRange FoodInFridgeOnStart { get; private set; } = new(4, 5);

        [field: SerializeField] public IntRange FoodBringPerBag { get; private set; } = new(3, 6);
    }
}
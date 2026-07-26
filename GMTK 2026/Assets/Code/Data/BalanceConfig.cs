using System;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class BalanceConfig : IService
    {
        [field: SerializeField] public float HourTickIntervalS { get; private set; } = 1f;

        [field: SerializeField] public int LifesCount { get; private set; } = 3;

        [field: SerializeField] public float PeopleArriveMinS { get; private set; } = 5f;
        [field: SerializeField] public float PeopleArriveMaxS { get; private set; } = 15f;

        [field: Tooltip("How Many Food Can Left in Fridge before People will go for new Items")]
        [field: SerializeField] public int MinFoodToBuyNewBatch { get; private set; }
    }
}
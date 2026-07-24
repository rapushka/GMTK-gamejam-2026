using System;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class BalanceConfig : IService
    {
        [field: SerializeField] public float HourTickIntervalS { get; private set; } = 1f;
    }
}
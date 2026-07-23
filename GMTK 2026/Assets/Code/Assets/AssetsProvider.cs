using System;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class AssetsProvider : IService
    {
        [field: SerializeField] public GameScreen GameScreenPrefab { get; private set; }
    }
}
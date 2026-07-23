using System;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
            _game = new();
            _game.Init();
        }

        private void Start()
        {
            _game.OnGameLoaded();
        }
    }
}
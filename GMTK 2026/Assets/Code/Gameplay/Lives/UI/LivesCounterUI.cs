using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    public class LivesCounterUI : MonoBehaviour
    {
        private static BalanceConfig Balance => ServiceLocator.Get<BalanceConfig>();

        [SerializeField] private SingleLifeUI _singleLifeUIPrefab;
        [SerializeField] private Transform _container;

        private readonly List<SingleLifeUI> _lives = new();

        public bool AreAllLivesLost => _lives.All(l => !l.IsFull);

        public void Init()
        {
            for (var i = 0; i < Balance.LifesCount; i++)
            {
                var live = Instantiate(_singleLifeUIPrefab, _container);
                live.Init();

                _lives.Add(live);
            }
        }

        public void LooseALife()
        {
            var life = _lives.First(l => l.IsFull);
            life.Loose();
        }
    }
}
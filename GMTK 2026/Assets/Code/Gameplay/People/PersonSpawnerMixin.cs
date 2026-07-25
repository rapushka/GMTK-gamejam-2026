using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class PersonSpawnerMixin
    {
        private static AssetsProvider  AssetsProvider  => ServiceLocator.Get<AssetsProvider>();
        private static ScreensMediator ScreensMediator => ServiceLocator.Get<ScreensMediator>();

        private readonly List<PersonComponent> _people = new();

        public void Init()
        {
            var fridge = ScreensMediator.GameScreen.Fridge;
            var container = fridge.PeopleContainer.transform;

            foreach (var prefab in AssetsProvider.PersonPrefabs)
            {
                var person = Object.Instantiate(prefab, container);
                person.Init();

                _people.Add(person);
            }
        }

        public PersonComponent PickRandom()
        {
            var randomIndex = Random.Range(0, _people.Count);
            return _people[randomIndex];
        }
    }
}
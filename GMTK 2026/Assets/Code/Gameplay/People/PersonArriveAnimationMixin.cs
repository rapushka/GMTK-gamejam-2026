using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Core
{
    public class PersonArriveAnimationMixin
    {
        private static ScreensMediator ScreensMediator => ServiceLocator.Get<ScreensMediator>();

        private readonly PeopleArriveSystem _peopleArriveSystem;

        private readonly Vector3 _initRotation = new(334.17f, 358.04f, 0.86f);
        private readonly Vector3 _targetRotation = new(346.75f, 299.09f, 22.39f);

        private static Fridge Fridge => ScreensMediator.GameScreen.Fridge;

        public PersonArriveAnimationMixin(PeopleArriveSystem peopleArriveSystem)
        {
            _peopleArriveSystem = peopleArriveSystem;
        }

        public async UniTask PlayArrive(PersonComponent person)
        {
            await Fridge.DoorPivot.transform.DORotate(_targetRotation, 0.5f)
                    .From(_initRotation)
                    .SetEase(Ease.OutCubic)
                    .Play()
                    .ToUniTask()
                ;

            await UniTask.WaitForSeconds(1f);

            await person.Appear();
        }
    }
}
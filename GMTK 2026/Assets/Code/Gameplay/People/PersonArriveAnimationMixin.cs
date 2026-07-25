using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Core
{
    public class PersonArriveAnimationMixin
    {
        private static ScreensMediator ScreensMediator => ServiceLocator.Get<ScreensMediator>();

        private readonly Vector3 _initRotation = new(334.17f, 358.04f, 0.86f);
        private readonly Vector3 _targetRotation = new(346.75f, 299.09f, 22.39f);

        private static Fridge Fridge => ScreensMediator.GameScreen.Fridge;

        public async UniTask PlayArrive(PersonComponent person)
        {
            // Fridge.DoorPivot.transform.eulerAngles = _initRotation;
            await Fridge.DoorPivot.transform.DORotate(_targetRotation, 0.5f)
                    // .From(_initRotation)
                    .SetEase(Ease.OutCubic)
                    .Play()
                    .ToUniTask()
                ;

            await UniTask.WaitForSeconds(0.4f);

            await person.Appear();
        }

        public async UniTask PlayHide(PersonComponent person)
        {
            await person.Hide();

            // Fridge.DoorPivot.transform.eulerAngles = _targetRotation;
            await Fridge.DoorPivot.transform.DORotate(_initRotation, 0.2f)
                    // .From(_targetRotation)
                    .SetEase(Ease.InExpo)
                    .Play()
                    .ToUniTask()
                ;
        }
    }
}
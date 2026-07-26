using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Core
{
    public class BringNewGroceriesMixin
    {
        private static BalanceConfig   BalanceConfig   => ServiceLocator.Get<BalanceConfig>();
        private static ItemsContainer  ItemsContainer  => ServiceLocator.Get<ItemsContainer>();
        private static AudioPlayer     AudioPlayer     => ServiceLocator.Get<AudioPlayer>();
        private static ItemSpawnSystem ItemSpawnSystem => ServiceLocator.Get<ItemSpawnSystem>();
        private static ScreensMediator ScreensMediator => ServiceLocator.Get<ScreensMediator>();

        public async UniTask UnpackNewFood(HandWithBagComponent bag)
        {
            var fridge = ScreensMediator.GameScreen.Fridge;

            var foodCountToBring = BalanceConfig.FoodBringPerBag.GetRandom();
            for (var i = 0; i < foodCountToBring; i++)
            {
                AudioPlayer.PlaySound(SoundKey.Pop);
                
                var item = ItemSpawnSystem.CreateItem();
                var targetPosition = fridge.CreateRandomPosition(item);

                FlyOutOfBag(item.transform, bag.FoodOrigin.position, targetPosition);

                await UniTask.WaitForSeconds(0.1f);
            }

            await UniTask.WaitForSeconds(0.45f);
        }

        private static void FlyOutOfBag(Transform item, Vector3 from, Vector3 to)
        {
            const float duration = 0.45f;
            const float arcHeight = 2f;

            item.position = from;
            item.localScale = Vector3.zero;

            var control = Vector3.Lerp(from, to, 0.4f) + Vector3.up * arcHeight;
            DOTween.Sequence()
                .Join(
                    DOTween.To(
                        () => 0f,
                        t => item.position = QuadBezier(from, control, to, t),
                        1f,
                        duration
                    ).SetEase(Ease.OutCubic)
                )
                .Join(item.DOScale(1f, duration).SetEase(Ease.OutBack))
                .Play();
        }

        private static Vector3 QuadBezier(Vector3 a, Vector3 c, Vector3 b, float t)
        {
            var u = 1f - t;
            return u * u * a + 2f * u * t * c + t * t * b;
        }
    }
}
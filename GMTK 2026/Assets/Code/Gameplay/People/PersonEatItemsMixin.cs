using Cysharp.Threading.Tasks;

namespace Core
{
    public class PersonEatItemsMixin
    {
        private static ItemsContainer ItemsContainer => ServiceLocator.Get<ItemsContainer>();

        public async UniTask EatItems()
        {
            await UniTask.WaitForSeconds(0.3f);

            // TODO: Eat more than 1 item?
            var randomItem = ItemsContainer.PickRandom();
            ItemsContainer.Eat(randomItem);

            await UniTask.WaitForSeconds(0.2f);
        }
    }
}
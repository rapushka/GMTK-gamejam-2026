using Cysharp.Threading.Tasks;

namespace Core
{
    public class BringNewGroceriesMixin
    {
        public async UniTask UnpackNewFood(PersonComponent handWithGroceries)
        {
            await UniTask.WaitForSeconds(10);
        }
    }
}
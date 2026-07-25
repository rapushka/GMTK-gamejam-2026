using UnityEngine;

namespace Core
{
    public class ItemPreviewSystem : IService
    {
        private static AssetsProvider       AssetsProvider   => ServiceLocator.Get<AssetsProvider>();
        private static ItemPreviewContainer PreviewContainer => ServiceLocator.Get<ItemPreviewContainer>();

        private Item3DPreview _currentPreview;

        public void Show(Item item)
        {
            var config = AssetsProvider.Items.GetItem(item.Key);
            _currentPreview = Object.Instantiate(config.ItemPrefab3D, PreviewContainer.transform);
        }

        public void Hide()
        {
            if (_currentPreview == null)
                return;

            Object.Destroy(_currentPreview.gameObject);
            _currentPreview = null;
        }
    }
}
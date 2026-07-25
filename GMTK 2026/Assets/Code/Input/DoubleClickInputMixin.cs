using UnityEngine;

namespace Core
{
    public class DoubleClickInputMixin
    {
        private static ItemPreviewSystem ItemPreviewSystem => ServiceLocator.Get<ItemPreviewSystem>();

        private Item _lastClickedItem;
        private float _lastClickTime;

        private bool IsUnderDoubleClickThreshold => Time.time - _lastClickTime < Constants.DoubleClickThreshold;

        public bool TryHandle(Item item)
        {
            if (item != _lastClickedItem || !IsUnderDoubleClickThreshold)
            {
                _lastClickTime = Time.time;
                _lastClickedItem = item;
                return false;
            }

            ItemPreviewSystem.Show(_lastClickedItem);
            return true;
        }
    }
}
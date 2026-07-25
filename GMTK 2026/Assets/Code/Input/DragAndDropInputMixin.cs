using UnityEngine;

namespace Core
{
    public class DragAndDropInputMixin
    {
        private Item _draggedItem;

        public bool IsDragging => _draggedItem != null;

        public void Begin(Item item, Vector2 mouseWorldPosition)
        {
            _draggedItem = item;
            _draggedItem.StartDrag(mouseWorldPosition);
        }

        public void Update(Vector2 mouseWorldPosition)
        {
            _draggedItem.Drag(mouseWorldPosition);
        }

        public void End()
        {
            if (_draggedItem == null)
                return;

            _draggedItem.EndDrag();
            _draggedItem = null;
        }
    }
}
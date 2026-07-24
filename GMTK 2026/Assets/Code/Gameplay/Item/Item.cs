using DefaultNamespace;
using UnityEngine;

namespace Core
{
    public class Item : MonoBehaviour
    {
        private State _state = State.Idle;
        private Vector2 _grabOffset;

        public Vector2 WorldPosition
        {
            get => transform.position;
            set => transform.position = value.WithZ(SortingZ.Item);
        }

        public void StartDrag(Vector2 mouseWorld)
        {
            _state = State.Dragged;
            _grabOffset = WorldPosition - mouseWorld;
        }

        public void Drag(Vector2 mouseWorld)
        {
            WorldPosition = mouseWorld + _grabOffset;
        }

        public void EndDrag()
        {
            _state = State.Settling;
            // TODO: look for shelves?
        }

        private enum State
        {
            Idle,
            Dragged,
            Settling,
        }
    }
}
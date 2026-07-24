using UnityEngine;

namespace Core
{
    public class UiRoot : MonoBehaviour, IService
    {
        private RectTransform _transform;

        public RectTransform Transform => _transform ?? GetComponent<RectTransform>();
    }
}
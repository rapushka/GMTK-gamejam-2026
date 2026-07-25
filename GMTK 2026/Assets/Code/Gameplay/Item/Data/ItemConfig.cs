using UnityEngine;

namespace Core
{
    [CreateAssetMenu(menuName = "GayJam/Item Config", fileName = "ItemConfig")]
    public class ItemConfig : ScriptableObject
    {
        [field: SerializeField] public ItemKey Key { get; private set; }

        [field: SerializeField] public Item          ItemPrefab2D { get; private set; }
        [field: SerializeField] public Item3DPreview ItemPrefab3D { get; private set; }

        [field: SerializeField] public int MinDaysToLive { get; private set; } = 1;
        [field: SerializeField] public int MaxDaysToLive { get; private set; } = 1;
    }
}
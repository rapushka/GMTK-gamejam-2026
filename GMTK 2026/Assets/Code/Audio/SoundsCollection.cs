using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class SoundsCollection
    {
        [SerializeField] private Entry[] _clips;

        private Dictionary<string, AudioClip> _map;

        public void Init()
        {
            _map = new(_clips.Length);
            foreach (var entry in _clips)
                _map.Add(entry.Key, entry.Clip);
        }

        public AudioClip Get(string key)
        {
#if DEBUG
            // ReSharper disable once ConvertIfStatementToReturnStatement - ifdef
            if (!_map.ContainsKey(key))
                throw new($"NO AUDIO CLIP WITH KEY {key} IN SOUNDS COLLECTION");
#endif

            return _map[key];
        }

        [Serializable]
        public class Entry
        {
            [field: SerializeField] public string    Key  { get; private set; }
            [field: SerializeField] public AudioClip Clip { get; private set; }
        }
    }
}
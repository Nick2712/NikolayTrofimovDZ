using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Flyweight
{
    internal sealed class LevelCompleted
    {
        private const string LEVEL_COMPLETED = "LevelCompleted";
        private readonly Dictionary<int, bool> _cache;

        public LevelCompleted()
        {
            _cache = new Dictionary<int, bool>();
        }

        public bool IsCompleted(int level)
        {
            if (_cache.TryGetValue(level, out bool isCompleted))
            {
                return isCompleted;
            }

            PlayerPrefs.SetString(GetPrefsKey(level), false.ToString());
            _cache[level] = isCompleted;
            return isCompleted;
        }


        public void SetCompleted(int level)
        {
            PlayerPrefs.SetString(GetPrefsKey(level), true.ToString());
            _cache[level] = true;
        }


        private string GetPrefsKey(int level) =>
            $"{LEVEL_COMPLETED}_{level}";
    }
}
using System;

namespace Asteroids.Prototype
{
    [Serializable]
    internal sealed class PlayerData
    {
        public float Speed;
        public Hp Hp;

        public override string ToString()
        {
            return $"Speed {Speed} Hp {Hp}";
        }
    }
}

using UnityEngine;

namespace Asteroids.Bridge
{
    internal sealed class Example : MonoBehaviour
    {
        private void Start()
        {
            var enemy = new Enemy(new MagicalAttack(), new Infantry());

            var enemyMage = new Enemy(new MagicalAttack(), new Walk());
            var enemyMelee = new Enemy(new PhysicalAttack(), new Run());
        }
    }
}

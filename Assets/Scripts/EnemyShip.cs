namespace Asteroids
{
    public class EnemyShip : Enemy
    {
        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }
    }
}
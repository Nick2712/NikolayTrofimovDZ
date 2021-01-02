using Asteroids.Abstrac_Factory;
using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private void Start()
        {
            EnemyPool enemyPool = new EnemyPool(5);
            var enemy = enemyPool.GetEnemy(NameManager.ASTEROID);
            enemy.transform.position = Vector3.one;
            enemy.gameObject.SetActive(true);

            var enemyShip = enemyPool.GetEnemy(NameManager.ENEMY_SHIP);
            enemyShip.transform.position = Vector3.one * 2;
            enemyShip.gameObject.SetActive(true);

            return;
            Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));

            IEnemyFactory factory = new AsteroidFactory();
            factory.Create(new Health(100.0f, 100.0f));

            Enemy.Factory.Create(new Health(100.0f, 100.0f));


            var platform = new PlatformFactory().Create(Application.platform);

            System.Threading.ThreadPool.QueueUserWorkItem(state => Debug.Log("Test"));
        }
    }
}

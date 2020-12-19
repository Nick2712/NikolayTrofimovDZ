using Asteroids.Abstrac_Factory;
using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private void Start()
        {
        }

        private void ExamplePool()
        {
            EnemyPool enemyPool = new EnemyPool(5);
            var enemy = enemyPool.GetEnemy("Asteroid");
            enemy.transform.position = Vector3.one;
            enemy.gameObject.SetActive(true);

            System.Threading.ThreadPool.QueueUserWorkItem(state => Debug.Log("Test"));
        }

        private void ExampleFactory()
        {
            Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));

            IEnemyFactory factory = new AsteroidFactory();
            factory.Create(new Health(100.0f, 100.0f));

            Enemy.Factory.Create(new Health(100.0f, 100.0f));

            new PlatformFactory().Create(Application.platform);

            System.Threading.Tasks.Task.Factory.StartNew(() => Debug.Log("Test"));
        }
    }
}

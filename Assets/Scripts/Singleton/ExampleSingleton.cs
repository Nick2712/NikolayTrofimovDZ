using UnityEngine;

namespace Asteroids.Singleton
{
    internal sealed class ExampleSingleton : MonoBehaviour
    {
        private void Start()
        {
            Services.Instance.Test();
            TestSingletonMonoBehaviour.Instance.Test();
        }
    }
}

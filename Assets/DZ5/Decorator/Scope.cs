using UnityEngine;

namespace Asteroids.Decorator
{
    public class Scope : IScope
    {
        public GameObject ScopeInstance { get; }

        public Scope(GameObject scopeInstance)
        {
            ScopeInstance = scopeInstance;
        }
    }
}
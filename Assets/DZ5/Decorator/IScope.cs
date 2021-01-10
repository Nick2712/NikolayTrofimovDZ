using UnityEngine;

namespace Asteroids.Decorator
{
    public interface IScope
    {
        GameObject ScopeInstance { get; }
    }
}
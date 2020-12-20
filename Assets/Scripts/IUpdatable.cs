using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public interface IUpdatable
    {
        void Execute(float deltaTime);
    }
}
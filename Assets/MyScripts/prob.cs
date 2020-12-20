using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class prob : MonoBehaviour
    {
        private void Start()
        {
            var enemy = Instantiate(Resources.Load<GameObject>("Enemy/Asteroid"));
            var renderer = enemy.GetComponent<Renderer>();
        }
    }
}
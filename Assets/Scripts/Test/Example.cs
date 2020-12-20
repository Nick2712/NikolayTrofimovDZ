using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids.Test
{
    internal sealed class Example
    {
        private void StartGame(IWeaponFactory weaponFactory)
        {
            // IPlayer player1 = new Player();
            IPlayer player2 = new PlayerFactory(weaponFactory).Creat(100.0f);
            Player.CreateMag(9, 9);
            Player.Factory.Creat(5);
        }

        public interface IPlayer
        {
        }

        public class Player : IPlayer
        {
            public static IPlayerFactory Factory = new PlayerFactory(null);
            private float _mana;
            public Player(float hp, IWeapon create)
            {
                
            }

            public static IPlayer CreateMag(float hp, float mana)
            {
                var player = new Player(hp, null);
                player._mana = mana;

                return player;
            }

            public static IPlayer CreateOrg(float hp, float mana)
            {
                var player = new Player(hp * 6, null);
                player._mana = 0.0f;

                return player;
            }
        }

        public interface IPlayerFactory
        {
            IPlayer Creat(float hp);
        }

        public class PlayerFactory : IPlayerFactory
        {
            private readonly IWeaponFactory _weaponFactory;

            public PlayerFactory(IWeaponFactory weaponFactory)
            {
                _weaponFactory = weaponFactory;
            }
            
            public IPlayer Creat(float hp)
            {
                return new Player(hp, _weaponFactory.Create());
            }
        }

        public interface IWeaponFactory
        {
            IWeapon Create();
        }
    }

    public interface IWeapon
    {
    }

    internal class ExampleMB : MonoBehaviour
    {
        private List<MonoBehaviour> _behaviours;

        public static void NameMethod(IDataAdapter adapter)
        {
            var addComponent = new GameObject("ExampleMB").AddComponent<ExampleMB>();
            addComponent._behaviours = new List<MonoBehaviour>();
        }

        private void Update()
        {
            foreach (var monoBehaviour in _behaviours)
            {
                //
            }
        }
    }
}

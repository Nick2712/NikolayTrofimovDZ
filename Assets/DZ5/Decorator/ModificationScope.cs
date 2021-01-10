using UnityEngine;

namespace Asteroids.Decorator
{
    internal sealed class ModificationScope : ModificationWeapon
    {
        private readonly IScope _scope;
        
        public ModificationScope(IScope scope)
        {
            _scope = scope;
        }

        protected override Weapon AddModification(Weapon weapon)
        {
            _modification = Object.Instantiate(_scope.ScopeInstance, _scope.ScopeInstance.transform.position,
                _scope.ScopeInstance.transform.rotation);
            return weapon;
        }

        protected override Weapon RemoveModification(Weapon weapon)
        {
            Object.Destroy(_modification);
            return weapon;
        }
    }
}
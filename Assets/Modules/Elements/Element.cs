using ExpPlus.BreakAway.Weapons;
using UnityEngine;

namespace ExpPlus.BreakAway.Health {

    [CreateAssetMenu(menuName = "Element")]
    public class Element : ScriptableObject {

        public WeaponBehaviour weaponBehaviour;
        public ElementAmmo ammo;
    }
}
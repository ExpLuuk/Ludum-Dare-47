using ExpPlus.LD47.Weapons;
using UnityEngine;

namespace ExpPlus.LD47.Common {

    [CreateAssetMenu(menuName = "Element")]
    public class Element : ScriptableObject {

        public WeaponBehaviour weaponBehaviour;
        public ElementAmmo ammo;
    }
}
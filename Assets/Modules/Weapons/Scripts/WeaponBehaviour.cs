using ExpPlus.BreakAway.Health;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExpPlus.BreakAway.Weapons {

    [CreateAssetMenu(menuName = "Weapon Profile", order = 0)]
    public class WeaponBehaviour : ScriptableObject {
        public GameObject projectilePrefab;

        public float fireRate = 1;
        public float projectileVelocity = 10;
    }
}
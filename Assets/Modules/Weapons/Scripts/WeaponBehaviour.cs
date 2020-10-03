using ExpPlus.LD47.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExpPlus.LD47.Weapons {

    [CreateAssetMenu(menuName = "Weapon Profile", order = 0)]
    public class WeaponBehaviour : ScriptableObject {
        public GameObject projectilePrefab;

        public float fireRate = 1;
        public float projectileVelocity = 10;
    }
}
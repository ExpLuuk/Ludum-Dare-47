using ExpPlus.BreakAway.Health;
using ExpPlus.BreakAway.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExpPlus.BreakAway.Common {
    public class ResetGame : MonoBehaviour {

        [SerializeField]
        private ElementAmmo airAmmo = default;
        [SerializeField]
        private ElementAmmo waterAmmo = default;
        [SerializeField]
        private ElementAmmo earthAmmo = default;
        [SerializeField]
        private ElementAmmo fireAmmo = default;
        [SerializeField]
        private HealthVariable health = default;

        // Start is called before the first frame update
        void Start() {

            airAmmo.ammo = -1;
            waterAmmo.ammo = 0;
            earthAmmo.ammo = 0;
            fireAmmo.ammo = 0;

            health.health = 1000;

            Destroy(gameObject);
        }
    }
}
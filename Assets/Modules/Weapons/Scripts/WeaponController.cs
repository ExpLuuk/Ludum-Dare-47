using UnityEngine;
using System.Collections.Generic;
using ExpPlus.LD47.Common;

namespace ExpPlus.LD47.Weapons {

    public class WeaponController : MonoBehaviour {

        public enum Mode { Player, Enemy }
        [Header("Config")]
        public Mode mode;
        public WeaponBehaviour activeWeaponBehaviour;
        public ElementAmmo activeElementAmmo;

        private float fireRateClock;

        // Start is called before the first frame update
        void Start() {

            if (activeWeaponBehaviour)
                fireRateClock = activeWeaponBehaviour.fireRate;
        }

        // Update is called once per frame
        void Update() {

            if (fireRateClock > 0)
                fireRateClock -= Time.deltaTime;
        }

        private void Fire() {

            //Handle firing here

            GameObject projectileGO = Instantiate(activeWeaponBehaviour.projectilePrefab, transform.position, transform.rotation);
            projectileGO.layer = LayerMask.NameToLayer(mode == Mode.Player ? "PlayerProjectiles" : "EnemyProjectiles");
            projectileGO.GetComponent<Rigidbody2D>().AddForce(transform.up * activeWeaponBehaviour.projectileVelocity, ForceMode2D.Impulse);

            if(activeElementAmmo && activeElementAmmo.ammo > 0)
                activeElementAmmo.ammo -= 1;

            fireRateClock = activeWeaponBehaviour.fireRate;
        }

        public void TryFire() {

            if (!activeWeaponBehaviour)
                return;

            if (fireRateClock <= 0) {

                if(activeElementAmmo == null || activeElementAmmo.ammo > 0 || activeElementAmmo.ammo == -1) {

                    Fire();
                }
            }
        }

        public void SwitchElement(Element element) {

            activeWeaponBehaviour = element.weaponBehaviour;
            activeElementAmmo = element.ammo;
            fireRateClock = activeWeaponBehaviour.fireRate;
        }
    }
}
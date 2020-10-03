using UnityEngine;

namespace ExpPlus.LD47.Weapons {

    public class WeaponController : MonoBehaviour {
        public WeaponBehaviour weaponBehaviour;
        public float fireRateClock;

        // Start is called before the first frame update
        void Start() {
            if (weaponBehaviour)
                fireRateClock = weaponBehaviour.fireRate;
        }

        // Update is called once per frame
        void Update() {

            if (fireRateClock > 0)
                fireRateClock -= Time.deltaTime;
        }

        private void Fire() {

            //Handle firing here

            GameObject projectile = Instantiate(weaponBehaviour.projectilePrefab, transform.position, transform.rotation);
            projectile.layer = LayerMask.NameToLayer("PlayerProjectiles");
            projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * weaponBehaviour.projectileVelocity, ForceMode2D.Impulse);
            projectile.GetComponent<Projectile>().damage = weaponBehaviour.damage;

            fireRateClock = weaponBehaviour.fireRate;
        }

        public void TryFire() {

            if (!weaponBehaviour)
                return;

            if (fireRateClock <= 0)
                Fire();
        }
    }
}
using UnityEngine;
using ExpPlus.LD47.Common;

namespace ExpPlus.LD47.Weapons {

    public class Projectile : MonoBehaviour {

        public int damage;

        private void OnCollisionEnter2D(Collision2D collision) {

            Health health = collision.collider.GetComponent<Health>();

            if (health != null) {

                health.Damage(damage);
            }

            Destroy(gameObject);
        }
    }
}
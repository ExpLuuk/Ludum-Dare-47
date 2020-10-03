using UnityEngine;
using ExpPlus.LD47.Common;

namespace ExpPlus.LD47.Weapons {

    public class Projectile : MonoBehaviour {

        public int damage = 1;
        public Element element;

        private void OnCollisionEnter2D(Collision2D collision) {

            Health health = collision.collider.GetComponent<Health>();

            if (health != null) {

                health.Damage(damage, element);
            }

            Destroy(gameObject);
        }
    }
}
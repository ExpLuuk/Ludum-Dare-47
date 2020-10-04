using UnityEngine;
using ExpPlus.BreakAway.Health;

namespace ExpPlus.BreakAway.Weapons {

    public class Projectile : MonoBehaviour {

        public int damage = 1;
        public Element element;

        private void OnCollisionEnter2D(Collision2D collision) {

            Health.Health health = collision.collider.GetComponent<Health.Health>();

            if (health != null) {

                health.Damage(damage, element);
            }

            Destroy(gameObject);
        }
    }
}
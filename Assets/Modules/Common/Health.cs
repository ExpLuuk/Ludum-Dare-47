using UnityEngine;

namespace ExpPlus.LD47.Common {

    public class Health : MonoBehaviour {

        public int health = 100;

        public void Damage(int damage) {

            health -= damage;

            if(health <= 0) {

                Destroy(gameObject);
            }
        }
    }
}
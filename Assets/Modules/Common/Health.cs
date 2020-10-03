using UnityEngine;
using System.Collections.Generic;

namespace ExpPlus.LD47.Common {

    public class Health : MonoBehaviour {

        public int health = 100;
        public List<Element> requiredElement = new List<Element>();

        public void Damage(int damage, Element element) {

            if (!requiredElement.Contains(element) && requiredElement.Count > 0)
                return;

            health -= damage;

            if(health <= 0) {

                Destroy(gameObject);
            }
        }
    }
}
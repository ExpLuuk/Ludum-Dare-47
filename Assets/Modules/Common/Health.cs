using UnityEngine;
using System.Collections.Generic;

namespace ExpPlus.LD47.Common {

    public class Health : MonoBehaviour {

        private IDeathHandler deathHandler;
        public int health = 100;
        public List<Element> requiredElement = new List<Element>();

        public void Damage(int damage, Element element) {

            if (!requiredElement.Contains(element) && requiredElement.Count > 0)
                return;

            health -= damage;

            if(health <= 0) {

                deathHandler = GetComponent<IDeathHandler>();

                if (deathHandler != null) {

                    deathHandler.IHandleDeath();
                    return;
                }

                Destroy(gameObject);
            }
        }
    }
}
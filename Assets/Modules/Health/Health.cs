using UnityEngine;
using System.Collections.Generic;

namespace ExpPlus.BreakAway.Health {

    public class Health : MonoBehaviour {

        [Header("References")]
        [SerializeField]
        private AudioSource hitAudioSource = default;
        [SerializeField]
        private AudioClip deathClip = default;
        [SerializeField]
        private GameObject deathParticlesPrefab = default;

        private IDeathHandler deathHandler;

        [Header("Config"), SerializeField]
        private bool useHealthVariable = false;
        [SerializeField]
        private HealthVariable healthVariable = default;

        [Header("Runtime Controls"), SerializeField]
        private int health = 100;
        public List<Element> requiredElement = new List<Element>();

        public void Damage(int damage, Element element) {

            if (!requiredElement.Contains(element) && requiredElement.Count > 0)
                return;

            bool died = false;

            if (useHealthVariable) {

                healthVariable.health -= damage;

                if (healthVariable.health <= 0) {
                    Debug.Log("We died");
                    died = true;
                }

            } else {

                health -= damage;

                if (health <= 0) {
                    died = true;
                }
            }

            if(died) {

                if (deathClip) {

                    GameObject audioSourceObject = new GameObject(gameObject.name + "_sound_death");
                    AudioSource audioSource = audioSourceObject.AddComponent<AudioSource>();
                    audioSource.PlayOneShot(deathClip);

                }

                if (deathParticlesPrefab) {

                    Instantiate(deathParticlesPrefab, transform.position, transform.rotation);
                }

                deathHandler = GetComponent<IDeathHandler>();

                if (deathHandler != null) {

                    deathHandler.IHandleDeath();
                    return;
                }

                Destroy(gameObject);
            }

            if(hitAudioSource)
                hitAudioSource.Play();
        }
    }
}
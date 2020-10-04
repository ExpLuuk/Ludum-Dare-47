using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ExpPlus.BreakAway.Health;
using ExpPlus.BreakAway.Weapons;
using ExpPlus.BreakAway.Enemies;

namespace ExpPlus.BreakAway.Altar {

    public class AltarController : MonoBehaviour {

        [Header("References")]
        public GameObject player;
        public Transform areaBeacon;
        [SerializeField]
        private AudioSource selectSource = default;

        [Header("Config")]
        public Element element;
        public float interactionRadius = 5f;
        public float areaRadius = 25f;
        [Space(10)]
        public GameObject enemyPrefab;
        public int maxFleetSize = 5;
        public float spawnFrequency = 2f;

        [Header("Runtime Controls")]
        public List<EnemyController> fleet = new List<EnemyController>();
        public bool attackingPlayer = false;
        public float spawnTimer;

        private void Start() {

            if (!player)
                player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update() {
            
            if(spawnTimer > 0) {
                spawnTimer -= Time.deltaTime;
            } else {

                if(fleet.Count < maxFleetSize) {

                    GameObject newEnemy = GameObject.Instantiate(enemyPrefab, GeneratePatrolTarget(), transform.rotation);
                    newEnemy.transform.SetParent(transform);
                    EnemyController enemyController = newEnemy.GetComponent<EnemyController>();

                    enemyController.altar = this;
                    enemyController.target = player.transform;
                    enemyController.patrolTarget = GeneratePatrolTarget();
                    enemyController.canAttackPlayer = attackingPlayer;

                    fleet.Add(enemyController);
                    spawnTimer = spawnFrequency;
                }
            }

            if(Vector3.Distance(areaBeacon.position, player.transform.position) < areaRadius) {

                if (!attackingPlayer) {

                    UpdateFleet(true);
                    attackingPlayer = true;
                }
            } else {

                if (attackingPlayer) {

                    UpdateFleet(false);
                    attackingPlayer = false;
                }
            }
        }

        private void UpdateFleet(bool canAttackPlayer) {

            for (int i = 0; i < fleet.Count; i++) {
                fleet[i].canAttackPlayer = canAttackPlayer;
            }
        }

        private void AttemptToUseAltar() {

            if(Vector3.Distance(transform.position, player.transform.position) <= interactionRadius) {

                player.GetComponent<WeaponController>().SwitchElement(element);

                selectSource.Play();
            }
        }

        public Vector3 GeneratePatrolTarget() {

            Vector3 generatedTarget = areaBeacon.position + (Random.insideUnitSphere * areaRadius);
            generatedTarget.z = 0;

            return generatedTarget;
        }

        #region Input Hooks
        public void GetAltarInteractionInput(InputAction.CallbackContext context) {

            if (context.performed) {

                AttemptToUseAltar();
            }
        }
        #endregion

        private void OnDrawGizmos() {

            Gizmos.DrawWireSphere(transform.position, interactionRadius);
            Gizmos.DrawWireSphere(areaBeacon ? areaBeacon.position : transform.position, areaRadius);
        }
    }
}
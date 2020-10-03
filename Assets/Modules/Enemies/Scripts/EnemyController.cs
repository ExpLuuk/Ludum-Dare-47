using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExpPlus.LD47.Weapons;
using ExpPlus.LD47.Common;
using ExpPlus.LD47.Altar;

namespace ExpPlus.LD47.Enemies {

    public class EnemyController : MonoBehaviour, IDeathHandler{

        [Header ("References")]
        [SerializeField]
        private Rigidbody2D rigidBody;
        [SerializeField]
        private WeaponController weaponController;
        public AltarController altar;
        public Transform target;

        [Header ("Config")]
        public float chaseSpeed = 3f;
        public float chaseStopRadius = 5f;
        public float chaseAttackRadius = 10f;
        [Space(10)]
        public float patrolSpeed = 2f;
        public float patrolStopDistance = .5f;

        [Header("Runtime Controls")]
        public bool canAttackPlayer = false;
        public Vector3 patrolTarget;

        // Start is called before the first frame update
        void Start() {

            rigidBody = GetComponent<Rigidbody2D>();

        }

        // Update is called once per frame
        void Update() {

            if (canAttackPlayer) {

                ChaseAndAttack();
            } else {

                Patrol();
            }

            UpdateRotation();
        }
        private void UpdateRotation() {

            Vector3 direction = (canAttackPlayer ? target.position  : patrolTarget) - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }

        private void ChaseAndAttack() {

            float distanceToPlayer = Vector3.Distance(transform.position, target.position);

            if (distanceToPlayer > chaseStopRadius) {

                rigidBody.AddForce(transform.up * chaseSpeed);
            } else {

                rigidBody.AddForce(transform.up * (chaseSpeed * (Vector3.Distance(transform.position, target.position) - chaseStopRadius)));
            }

            if (distanceToPlayer < chaseAttackRadius) {

                weaponController.TryFire();
            }
        }

        private void Patrol() {

            if(Vector3.Distance(transform.position, patrolTarget) <= patrolStopDistance) {
                
                patrolTarget = altar.GeneratePatrolTarget();                
            }

            rigidBody.AddForce(transform.up * patrolSpeed);
        }
        public void IHandleDeath() {

            altar.fleet.Remove(this);
            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExpPlus.LD47.Weapons;

namespace ExpPlus.LD47.Enemies {

    public class EnemyController : MonoBehaviour {

        [Header ("References")]
        [SerializeField]
        private Rigidbody2D rigidBody;
        public Transform target;
        public WeaponController weaponController;

        [Header ("Config")]
        public float speed = 1f;
        public float stopRadius = 5f;
        public float attackRadius = 10f;

        [Header("Runtime Controls")]
        public bool canAttackPlayer = false;

        // Start is called before the first frame update
        void Start() {

            rigidBody = GetComponent<Rigidbody2D>();

        }

        // Update is called once per frame
        void Update() {

            float distanceToPlayer = Vector3.Distance(transform.position, target.position);

            if (distanceToPlayer > stopRadius) {

                rigidBody.AddForce(transform.up * speed);
            } else {

                rigidBody.AddForce(transform.up * (speed * (Vector3.Distance(transform.position, target.position) - stopRadius)));
            }

            if(distanceToPlayer < attackRadius) {

                weaponController.TryFire();
            }

            UpdateRotation();
        }
        private void UpdateRotation() {

            Vector3 direction = target.position - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }

    }
}
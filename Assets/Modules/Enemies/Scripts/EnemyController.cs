using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExpPlus.LD47.Enemies {

    public class EnemyController : MonoBehaviour {

        private Rigidbody2D rigidBody;
        public Transform target;

        public float speed = 10f;
        public float minPersuitRadius = 10f;

        // Start is called before the first frame update
        void Start() {

            rigidBody = GetComponent<Rigidbody2D>();

        }

        // Update is called once per frame
        void Update() {

            if(Vector3.Distance(transform.position, target.position) > minPersuitRadius) {

                rigidBody.AddForce(transform.up * speed);
            } else {

                rigidBody.AddForce(transform.up * (speed * (Vector3.Distance(transform.position, target.position) - minPersuitRadius)));
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
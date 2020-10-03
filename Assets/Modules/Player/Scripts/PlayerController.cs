using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ExpPlus.LD47.Player {

    public class PlayerController : MonoBehaviour {

        private Vector2 movementInput;
        private Vector2 orientationalInput;

        private Rigidbody2D rigidbody;

        public Camera camera;

        public float speed = 10;

        // Start is called before the first frame update
        void Start() {

            rigidbody = GetComponent<Rigidbody2D>();
            //camera = Camera.main;
        }

        // Update is called once per frame
        void Update() {

            Vector3 pointerWorldPos = camera.ScreenToWorldPoint(new Vector3(orientationalInput.x, orientationalInput.y, camera.nearClipPlane));
            Vector3 direction = pointerWorldPos - transform.position;
            Debug.DrawLine(transform.position, pointerWorldPos, Color.green);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }

        private void FixedUpdate() {

            rigidbody.AddForce(movementInput * speed, ForceMode2D.Force);
        }

        #region InputHooks
        public void GetMovementInput(InputAction.CallbackContext context) {

            movementInput = context.ReadValue<Vector2>();
        }

        public void GetOrientationalInput(InputAction.CallbackContext context) {

            orientationalInput = context.ReadValue<Vector2>();
        }
        #endregion
    }
}
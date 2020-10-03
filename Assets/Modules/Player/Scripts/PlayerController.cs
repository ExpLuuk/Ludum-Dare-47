using UnityEngine;
using UnityEngine.InputSystem;
using ExpPlus.LD47.Weapons;

namespace ExpPlus.LD47.Player {

    public class PlayerController : MonoBehaviour {

        private Vector2 movementInput;
        private Vector2 orientationalInput;
        private bool holdingFire;

        private Rigidbody2D rigidBody;
        private WeaponController weaponController;
        private new Camera camera;

        public float speed = 10;

        // Start is called before the first frame update
        void Start() {

            rigidBody = GetComponent<Rigidbody2D>();
            weaponController = GetComponent<WeaponController>();
            camera = Camera.main;
        }

        // Update is called once per frame
        void Update() {

            UpdateRotation();

            if (holdingFire)
                weaponController.TryFire();

        }

        private void FixedUpdate() {

            rigidBody.AddForce(movementInput * speed, ForceMode2D.Force);
        }

        private void UpdateRotation() {

            Vector3 pointerWorldPos = camera.ScreenToWorldPoint(new Vector3(orientationalInput.x, orientationalInput.y, camera.nearClipPlane));
            Vector3 direction = pointerWorldPos - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }

        #region InputHooks

        public void GetShootingInput(InputAction.CallbackContext context) {

            if (context.started)
                holdingFire = true;

            if (context.canceled) 
                holdingFire = false;
        }

        public void GetMovementInput(InputAction.CallbackContext context) {

            movementInput = context.ReadValue<Vector2>();
        }

        public void GetOrientationalInput(InputAction.CallbackContext context) {

            orientationalInput = context.ReadValue<Vector2>();
        }
        #endregion
    }
}
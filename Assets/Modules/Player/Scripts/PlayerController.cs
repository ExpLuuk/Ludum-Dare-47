using UnityEngine;
using UnityEngine.InputSystem;
using ExpPlus.BreakAway.Weapons;
using ExpPlus.BreakAway.Health;

namespace ExpPlus.BreakAway.Player {

    public class PlayerController : MonoBehaviour, IDeathHandler  {

        [Header("References")]
        [SerializeField]
        private Rigidbody2D rigidBody;
        [SerializeField]
        private WeaponController weaponController;
        [SerializeField]
        private new Camera camera;
        [SerializeField]
        private GameObject gameOverScreen = default;
        [SerializeField]
        private GameObject wonScreen = default;

        [Header ("Runtime Controls")]
        [SerializeField]
        private Vector2 movementInput;
        [SerializeField]
        private Vector2 orientationalInput;
        [SerializeField]
        private bool holdingFire;

        public float speed = 10;

        // Start is called before the first frame update
        void Start() {

            rigidBody = GetComponent<Rigidbody2D>();
            weaponController = GetComponent<WeaponController>();
            camera = Camera.main;
        }

        // Update is called once per frame
        void Update() {

            if(Vector3.Distance(new Vector3(50,50,0), transform.position) > 50f) {

                wonScreen.SetActive(true);

                Destroy(GameObject.Find("Altars"));

                Destroy(gameObject);
            }

            UpdateRotation();

            if (holdingFire)
                weaponController.TryFire();
        }

        // FixedUpdate is called on a fixed timestep
        private void FixedUpdate() {

            rigidBody.AddForce(movementInput * speed, ForceMode2D.Force);
        }

        private void UpdateRotation() {

            Vector3 pointerWorldPos = camera.ScreenToWorldPoint(new Vector3(orientationalInput.x, orientationalInput.y, camera.nearClipPlane));
            Vector3 direction = pointerWorldPos - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }

        public void IHandleDeath() {

            gameOverScreen.SetActive(true);

            Destroy(GameObject.Find("Altars"));

            Destroy(gameObject);
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
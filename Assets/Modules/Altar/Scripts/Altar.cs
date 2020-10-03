using UnityEngine;
using UnityEngine.InputSystem;
using ExpPlus.LD47.Common;
using ExpPlus.LD47.Weapons;

namespace ExpPlus.LD47.Altar {

    public class Altar : MonoBehaviour {

        [Header("References")]
        public GameObject player;

        [Header("Config")]
        public Element element;
        public float interactionRadius = 5f;

        private void Start() {

            if (!player)
                player = GameObject.FindGameObjectWithTag("Player");
        }

        private void AttemptToUseAltar() {

            if(Vector3.Distance(transform.position, player.transform.position) <= interactionRadius) {

                player.GetComponent<WeaponController>().SwitchElement(element);
            }
        }

        public void GetAltarInteractionInput(InputAction.CallbackContext context) {

            if (context.performed) {

                Debug.Log("Activated");

                AttemptToUseAltar();
            }
        }
    }
}
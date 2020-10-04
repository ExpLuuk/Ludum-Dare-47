using ExpPlus.BreakAway.Health;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ExpPlus.BreakAway.UI {
    public class SetHealthbar : MonoBehaviour {


        [SerializeField]
        private Image healthbar = default;
        [SerializeField]
        private HealthVariable healthVariable = default;
        [SerializeField]
        private float fillAmount;
        // Update is called once per frame
        void Update() {

            fillAmount = (float)healthVariable.health / 1000;
            healthbar.fillAmount = (float)healthVariable.health / 1000;
        }
    }
}

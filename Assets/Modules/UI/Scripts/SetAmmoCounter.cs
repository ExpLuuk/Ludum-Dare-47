using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ExpPlus.BreakAway.Weapons;

namespace ExpPlus.BreakAway.UI {
    public class SetAmmoCounter : MonoBehaviour {

        [SerializeField]
        private TMP_Text counter = default;
        [SerializeField]
        private ElementAmmo ammo = default; 

        // Update is called once per frame
        void Update() {

            counter.text = ammo.ammo.ToString();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExpPlus.BreakAway.Health {

    [CreateAssetMenu(menuName = "Health Variable")]
    public class HealthVariable : ScriptableObject {

        public int health = 100;
    }
}
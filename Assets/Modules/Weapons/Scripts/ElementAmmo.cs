using ExpPlus.BreakAway.Health;
using UnityEngine;

namespace ExpPlus.BreakAway.Weapons {

    [CreateAssetMenu(menuName = "Element Ammo")]
    public class ElementAmmo : ScriptableObject {

        public Element element;
        public int ammo = -1;
    }
}
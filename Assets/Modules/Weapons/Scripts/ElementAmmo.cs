using ExpPlus.LD47.Common;
using UnityEngine;

namespace ExpPlus.LD47.Weapons {

    [CreateAssetMenu(menuName = "Element Ammo")]
    public class ElementAmmo : ScriptableObject {

        public Element element;
        public int ammo = -1;
    }
}
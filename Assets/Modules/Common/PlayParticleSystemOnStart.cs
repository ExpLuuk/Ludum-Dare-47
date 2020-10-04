using UnityEngine;

namespace ExpPlus.BreakAway.Common {

    public class PlayParticleSystemOnStart : MonoBehaviour {

        [SerializeField]
        private new ParticleSystem particleSystem = default;
        

        void Start() {

            if (particleSystem)
                particleSystem.Play();
        }
    }
}

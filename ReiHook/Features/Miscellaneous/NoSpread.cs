using UnityEngine;
using ReiHook.Utilities;
namespace ReiHook.Features.Miscellaneous {
    internal class NoSpread : MonoBehaviour {
        private void Update() {
            if (Settings.NoSpread) {
                DeadHunter.dispersion_arma_max = 0f;
                DeadHunter.dispersion_arma_min = 0f;
                DeadHunter.dispersion_disparo_max = 0f;
                DeadHunter.dispersion_disparo_min = 0f;
            }
        }
    }
}

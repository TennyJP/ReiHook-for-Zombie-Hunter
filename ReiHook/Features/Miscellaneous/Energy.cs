using ReiHook.Utilities;
using UnityEngine;
namespace ReiHook.Features.Miscellaneous {
    public class Energy : MonoBehaviour {
        private void Update() {
            if (Settings.Energy) {
                PlayerPrefs.SetInt("actual_hearts", 10);
            }
        }
    }
}

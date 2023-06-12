using UnityEngine;
namespace ReiHook.Features.Miscellaneous {
    public class Gold : MonoBehaviour {
        public static void MaxGold() {
            SaveLoadData.SaveInt("gold", 2147483647, true);
        }
    }
}

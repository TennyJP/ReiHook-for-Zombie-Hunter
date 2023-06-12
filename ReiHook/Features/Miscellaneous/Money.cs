using UnityEngine;
namespace ReiHook.Features.Miscellaneous {
    public class Money : MonoBehaviour {
        public static void MaxMoney() {
            SaveLoadData.SaveInt("money", 2147483647, true);
        }
    }
}

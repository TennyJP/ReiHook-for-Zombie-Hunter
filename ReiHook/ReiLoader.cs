using UnityEngine;
namespace ReiHook {
    public class ReiLoader : MonoBehaviour {
        public static GameObject pLoader;
        public static void ReiAyanami() {
            pLoader = new GameObject();
            pLoader.AddComponent<UI.Menu>();
            pLoader.AddComponent<Features.Visuals.ESP>();
            pLoader.AddComponent<Features.Miscellaneous.Energy>();
            pLoader.AddComponent<Features.Miscellaneous.NoSpread>();
            DontDestroyOnLoad(pLoader);
        }

        public static void ReiUnload() {
            Destroy(pLoader);
        }
    }
}

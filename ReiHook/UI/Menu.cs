using UnityEngine;
using ReiHook.Utilities;
namespace ReiHook.UI {
    public class Menu : MonoBehaviour {
        private Rect MainWindow;
        private Rect VisualWindow;
        private Rect MiscellaneousWindow;

        GUIStyle WatermarkStyle = new GUIStyle();
        GUIStyle LabelStyle = new GUIStyle();

        private bool bGUI = false;
        private bool bVisualWindow = false;
        private bool bMiscellaneousWindow = false;
        private void Start() {
            MainWindow = new Rect(20f, 60f, 250f, 100f);
            WatermarkStyle.normal.textColor = Color.yellow; LabelStyle.normal.textColor = Color.white;
        }

        private void Update() {
            ToggleMenu();
            if(Input.GetKeyDown(KeyCode.Delete)) { ReiLoader.ReiUnload(); }
        }

        private void ToggleMenu() {
            if (Input.GetKeyDown(KeyCode.F4)) {
                bGUI = !bGUI;
            }
        }

        private void OnGUI() {
            GUI.Label(new Rect(20, 20, 200, 60), "UnKnoWnCheaTs.me | Tenny", WatermarkStyle); GUI.Label(new Rect(20, 40, 200, 60), "ReiHook for Zombie Hunter v1.0", WatermarkStyle);
            if (!bGUI) return;
            GUI.backgroundColor = Color.grey; GUI.contentColor = Color.white;
            MainWindow = GUILayout.Window(0, MainWindow, new GUI.WindowFunction(UI), "ReiHook for Zombie Hunter", new GUILayoutOption[0]);
            if (bVisualWindow) { VisualWindow = GUILayout.Window(1, VisualWindow, new GUI.WindowFunction(UI), "Visual", new GUILayoutOption[0]); }
            if (bMiscellaneousWindow) { MiscellaneousWindow = GUILayout.Window(2, MiscellaneousWindow, new GUI.WindowFunction(UI), "Miscellaneous", new GUILayoutOption[0]); }
        }

        private void UI(int pID) {
            GUI.backgroundColor = Color.grey; GUI.contentColor = Color.white;
            switch (pID) {
                case 0:
                    GUILayout.Label("Press F4 for Menu", LabelStyle, new GUILayoutOption[0]);
                    GUILayout.Label("Delete to Unhook the Cheat", LabelStyle, new GUILayoutOption[0]);
                    if (GUILayout.Button("Visual", new GUILayoutOption[0])) { bVisualWindow = !bVisualWindow; }
                    if (GUILayout.Button("Miscellaneous", new GUILayoutOption[0])) { bMiscellaneousWindow = !bMiscellaneousWindow; }
                    break;
                case 1:
                    Settings.ESP = GUILayout.Toggle(Settings.ESP, "Enable ESP", new GUILayoutOption[0]);
                    Settings.Player = GUILayout.Toggle(Settings.Player, "Player", new GUILayoutOption[0]);
                    Settings.PlayerSkeleton = GUILayout.Toggle(Settings.PlayerSkeleton, "Player Skeleton", new GUILayoutOption[0]);
                    Settings.Zombie = GUILayout.Toggle(Settings.Zombie, "Zombie", new GUILayoutOption[0]);
                    Settings.ZombieSkeleton = GUILayout.Toggle(Settings.ZombieSkeleton, "Zombie Skeleton", new GUILayoutOption[0]);
                    break;
                case 2:
                    Settings.NoSpread = GUILayout.Toggle(Settings.NoSpread, "No Spread", new GUILayoutOption[0]);
                    Settings.Energy = GUILayout.Toggle(Settings.Energy, "Unlimited Energy", new GUILayoutOption[0]);
                    if (GUILayout.Button("Max Gold", new GUILayoutOption[0])) { Features.Miscellaneous.Gold.MaxGold(); }
                    if (GUILayout.Button("Max Money", new GUILayoutOption[0])) { Features.Miscellaneous.Money.MaxMoney(); }
                    break;
                default:
                    break;
            }
            GUI.DragWindow();
        }
    }
}

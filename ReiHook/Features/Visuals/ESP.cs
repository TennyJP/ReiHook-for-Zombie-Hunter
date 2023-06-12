using UnityEngine;
using ReiHook.Utilities;
namespace ReiHook.Features.Visuals {
    public class ESP : MonoBehaviour {
        public static Camera ReiCamera;
        private void Update() {
            ReiCamera = Camera.main;
        }

        private void OnGUI() {
            if (Event.current.type != EventType.Repaint) return;
            if (Settings.ESP) {
                if (Settings.Zombie || Settings.Player || Settings.ZombieSkeleton || Settings.PlayerSkeleton) {
                    foreach (PersonControl2 person in FindObjectsOfType<PersonControl2>()) {
                        if (!person || person.isdead) continue;
                        Vector3 WorldToScreen = ReiCamera.WorldToScreenPoint(person.transform.position);
                        float ReiDistance = Vector3.Distance(ReiCamera.transform.position, person.transform.position);
                        Animator animator = person.GetComponent<Animator>();
                        if (Render.IsOnScreen(WorldToScreen)) {
                            if (Settings.Player && person.ishuman) {
                                Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Human", Color.green, true, 12, FontStyle.Normal);
                                Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y + 12), Mathf.Round(ReiDistance) + "m", Color.yellow, true, 12, FontStyle.Normal);
                            }
                            if (Settings.PlayerSkeleton && person.ishuman) {
                                Skeleton(animator, Color.gray);
                            }
                            if (Settings.Zombie && !person.ishuman) {
                                Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y), "Zombie", Color.red, true, 12, FontStyle.Normal);
                                Render.DrawString(new Vector2(WorldToScreen.x, Screen.height - WorldToScreen.y + 12), Mathf.Round(ReiDistance) + "m", Color.yellow, true, 12, FontStyle.Normal);
                            }
                            if (Settings.ZombieSkeleton && !person.ishuman) {
                                Skeleton(animator, Color.red);
                            }
                        }
                    }
                }
            }
        }

        private static readonly HumanBodyBones[] ZombieBones =
        {
            HumanBodyBones.Head,
            HumanBodyBones.Neck,
            HumanBodyBones.Chest,
            HumanBodyBones.LeftShoulder,
            HumanBodyBones.LeftUpperArm,
            HumanBodyBones.LeftLowerArm,
            HumanBodyBones.LeftHand,
            HumanBodyBones.RightShoulder,
            HumanBodyBones.RightUpperArm,
            HumanBodyBones.RightLowerArm,
            HumanBodyBones.RightHand,
            HumanBodyBones.Hips,
            HumanBodyBones.LeftUpperLeg,
            HumanBodyBones.LeftLowerLeg,
            HumanBodyBones.LeftFoot,
            HumanBodyBones.RightUpperLeg,
            HumanBodyBones.RightLowerLeg,
            HumanBodyBones.RightFoot
        };

        private static void Skeleton(Animator animator, Color color) {
            if (animator == null || !animator.isHuman || !animator.isInitialized) { return; }
            Vector3[] BoneArray = new Vector3[ZombieBones.Length];
            for (int i = 0; i < ZombieBones.Length; i++) {
                Transform BonePosition = animator.GetBoneTransform(ZombieBones[i]);
                if (BonePosition != null) BoneArray[i] = Render.WorldToScreenPoint(BonePosition.position);
                else return;
            }
            if (Settings.PlayerSkeleton || Settings.ZombieSkeleton) {
                Render.DrawLine(BoneArray[0], BoneArray[1], 1f, color);
                Render.DrawLine(BoneArray[1], BoneArray[2], 1f, color);
                Render.DrawLine(BoneArray[2], BoneArray[3], 1f, color);
                Render.DrawLine(BoneArray[2], BoneArray[7], 1f, color);
                Render.DrawLine(BoneArray[3], BoneArray[4], 1f, color);
                Render.DrawLine(BoneArray[4], BoneArray[5], 1f, color);
                Render.DrawLine(BoneArray[5], BoneArray[6], 1f, color);
                Render.DrawLine(BoneArray[7], BoneArray[8], 1f, color);
                Render.DrawLine(BoneArray[8], BoneArray[9], 1f, color);
                Render.DrawLine(BoneArray[9], BoneArray[10], 1f, color);
                Render.DrawLine(BoneArray[2], BoneArray[11], 1f, color);
                Render.DrawLine(BoneArray[11], BoneArray[12], 1f, color);
                Render.DrawLine(BoneArray[11], BoneArray[15], 1f, color);
                Render.DrawLine(BoneArray[12], BoneArray[13], 1f, color);
                Render.DrawLine(BoneArray[13], BoneArray[14], 1f, color);
                Render.DrawLine(BoneArray[15], BoneArray[16], 1f, color);
                Render.DrawLine(BoneArray[16], BoneArray[17], 1f, color);
            }
        }
    }
}

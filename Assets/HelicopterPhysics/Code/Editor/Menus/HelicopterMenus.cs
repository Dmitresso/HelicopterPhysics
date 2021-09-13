using UnityEditor;
using UnityEngine;


namespace WheelApps {
    public class HelicopterMenus {
        [MenuItem("WheelApps/Vehicles/Setup New Helicopter")]
        public static void BuildNewHelicopter() {
            var currentHelicopter = new GameObject("Helicopter", typeof(HelicopterController));
            var currentCOM = new GameObject("COM");
            var audioGRP = new GameObject("Audio_GRP");
            var graphicsGRP = new GameObject("Graphics_GRP");
            var collisionGRP = new GameObject("Collision_GRP");
            var currentController = currentHelicopter.GetComponent<HelicopterController>();

            currentCOM.transform.SetParent(currentHelicopter.transform);
            audioGRP.transform.SetParent(currentHelicopter.transform);
            graphicsGRP.transform.SetParent(currentHelicopter.transform);
            collisionGRP.transform.SetParent(currentHelicopter.transform);
            
            currentController.com = currentCOM.transform;
            
            Selection.activeGameObject = currentHelicopter;
        }
    }
}
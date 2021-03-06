using UnityEditor;
using UnityEngine;


namespace WheelApps {
    public class HelicopterMenus {
        [MenuItem("WheelApps/Vehicles/Setup New Helicopter")]
        public static void BuildNewHelicopter() {
            var currentHelicopter = new GameObject("Helicopter", typeof(HelicopterController));
            var currentCOM = new GameObject("COM");
            var audioGRP = new GameObject("Audio_GRP");
            var graphicsGRP = new GameObject("Graphic_GRP");
            var collisionGRP = new GameObject("Collision_GRP");
            var engineGRP = new GameObject("Engine_GRP");
            var rotorGRP = new GameObject("Rotor_GRP");

            var currentController = currentHelicopter.GetComponent<HelicopterController>();
            
            SetupRotorGRP(rotorGRP, currentController);
            SetupEngineGRP(engineGRP, currentController);


            currentCOM.transform.SetParent(currentHelicopter.transform);
            audioGRP.transform.SetParent(currentHelicopter.transform);
            graphicsGRP.transform.SetParent(currentHelicopter.transform);
            collisionGRP.transform.SetParent(currentHelicopter.transform);
            engineGRP.transform.SetParent(currentHelicopter.transform);
            rotorGRP.transform.SetParent(currentHelicopter.transform);

            currentController.com = currentCOM.transform;

            Selection.activeGameObject = currentHelicopter;
        }


        public static void SetupRotorGRP(GameObject rotorGO, HelicopterController controller) {
            var rotorController = rotorGO.AddComponent<RotorController>();
            controller.rotorController = rotorController;
            
            var mainGRP = new GameObject("MainRotor");
            var tailGRP = new GameObject("TailRotor");
            mainGRP.AddComponent<MainHelicopterRotor>();
            tailGRP.AddComponent<TailHelicopterRotor>();
            mainGRP.transform.SetParent(rotorGO.transform);
            tailGRP.transform.SetParent(rotorGO.transform);
        }


        public static void SetupEngineGRP(GameObject engineGO, HelicopterController controller) {
            var engineGRP = new GameObject("MainEngine");
            var engine = engineGRP.AddComponent<HelicopterEngine>();
            controller.engines.Add(engine);
            engineGRP.transform.SetParent(engineGO.transform);
        }
    }
}
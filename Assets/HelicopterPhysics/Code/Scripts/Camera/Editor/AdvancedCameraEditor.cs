using UnityEditor;
using UnityEngine;


namespace WheelApps {
    [CustomEditor(typeof(AdvancedCamera))]
    public class AdvancedCameraEditor : Editor {
        #region Variables
        private AdvancedCamera targetCamera;
        #endregion



        #region Methods
        private void OnEnable() {
            targetCamera = (AdvancedCamera) target;
        }


        private void OnSceneGUI() {
            var minDistance = targetCamera.minDistance;
            var maxDistance = targetCamera.maxDistance;
            var targetForward = targetCamera.rb.transform.forward;
            
            
            Handles.color = Color.blue;
            Handles.DrawWireDisc(targetCamera.rb.position, Vector3.up, minDistance);
            Handles.DrawWireDisc(targetCamera.rb.position, Vector3.up, maxDistance);

            targetCamera.minDistance = Handles.ScaleSlider(targetCamera.minDistance, targetCamera.rb.position, Vector3.forward + targetForward * minDistance, Quaternion.identity, 1f, 0f);
            targetCamera.maxDistance = Handles.ScaleSlider(targetCamera.maxDistance, targetCamera.rb.position, Vector3.back - targetForward * maxDistance, Quaternion.identity, 1f, 0f);
        }
        #endregion
    }
}
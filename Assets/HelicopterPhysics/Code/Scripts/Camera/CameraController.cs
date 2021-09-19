using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace WheelApps {
    public class CameraController : MonoBehaviour {
        #region Variables
        [Header("Cameras Properties")]
        public int startIndex = 1;
        
        private List<BaseCamera> cameras = new List<BaseCamera>();
        private int currentCameraIndex;
        #endregion



        #region Builtin Methods
        private void Start() {
            cameras = GetComponentsInChildren<BaseCamera>().ToList();
            if (startIndex >= cameras.Count) startIndex = cameras.Count - 1;
            currentCameraIndex = startIndex;
        }
        #endregion



        #region Custom Methods
        public void SwitchCamera() {
            currentCameraIndex++;
            HandleSwitch();
        }


        public void SwitchCamera(int index) {
            HandleSwitch();
        }


        private void HandleSwitch() {
            if (currentCameraIndex == cameras.Count) currentCameraIndex = 0; 
            for (var i = 0; i < cameras.Count; i++) {
                var currentCamera = cameras[currentCameraIndex].gameObject;
                currentCamera.SetActive(false);
                if (i == currentCameraIndex) currentCamera.SetActive(true);
            }
        }
        #endregion
    }
}
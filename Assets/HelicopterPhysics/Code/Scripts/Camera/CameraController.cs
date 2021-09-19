using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace WheelApps {
    public class CameraController : MonoBehaviour {
        #region Variables
        [Header("Cameras Properties")]
        public int startIndex;
        
        private List<BaseCamera> cameras = new List<BaseCamera>();
        private int currentCameraIndex;
        #endregion



        #region Builtin Methods
        private void Start() {
            cameras = GetComponentsInChildren<BaseCamera>().ToList();
            if (startIndex >= cameras.Count) startIndex = cameras.Count - 1;
            currentCameraIndex = startIndex;
            SwitchCamera(startIndex);
        }
        #endregion



        #region Custom Methods
        public void SwitchCamera() {
            currentCameraIndex++;
            HandleSwitch();
        }


        public void SwitchCamera(int index) {
            HandleSwitch(index);
        }


        private void HandleSwitch(int index = -1) {
            if (index >= 0) currentCameraIndex = index;
            if (currentCameraIndex == cameras.Count) currentCameraIndex = 0; 
            
            for (var i = 0; i < cameras.Count; i++) {
                cameras[i].gameObject.SetActive(false);
                if (i == currentCameraIndex) {
                    cameras[currentCameraIndex].gameObject.SetActive(true);
                }
            }
        }
        #endregion
    }
}
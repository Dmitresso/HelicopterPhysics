using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace WheelApps {
    public class CameraController : MonoBehaviour {
        #region Variables
        [Header("Cameras Properties")]
        public int startIndex;
        
        private List<BaseCamera> cameras = new List<BaseCamera>();
        private List<Camera> _cameras = new List<Camera>();
        private int currentCameraIndex;
        #endregion



        #region Builtin Methods
        private void OnEnable() {
            cameras = GetComponentsInChildren<BaseCamera>().ToList();
            foreach (var camera in cameras) _cameras.Add(camera.GetComponent<Camera>());
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
            if (currentCameraIndex == _cameras.Count) currentCameraIndex = 0; 
            
            for (var i = 0; i < _cameras.Count; i++) {
                _cameras[i].enabled = false;
                if (i == currentCameraIndex) _cameras[currentCameraIndex].enabled = true;
            }
        }
        #endregion
    }
}
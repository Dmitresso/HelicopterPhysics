using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace WheelApps {
    public class CameraController : MonoBehaviour {
        #region Variables
        public List<BaseCamera> cameras = new List<BaseCamera>();
        #endregion



        #region Builtin Methods

        private void Start() {
            cameras = GetComponentsInChildren<BaseCamera>().ToList();
            foreach (var camera in cameras) {
                // Debug.Log(camera.gameObject.name);
            }
        }

        #endregion



        #region Custom Methods
        public void SwitchCamera() {
            Debug.Log("Camera Switch called");
        }
        #endregion
    }
}
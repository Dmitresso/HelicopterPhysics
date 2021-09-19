using UnityEngine;


namespace WheelApps {
    public class CockpitCamera : BaseCamera, IHelicopterCamera {
        #region Variables
        [Header("Cockpit Camera Properties")]
        public Transform cockpitPosition;
        public Vector3 offset = Vector3.zero;
        public float fov = 55f;
        
        private Vector3 startOffset;
        #endregion
        
        
        
        #region Builtin Methods
        private void OnEnable() {
            updateEvent.AddListener(UpdateCamera);
        }


        private void OnDisable() {
            updateEvent.RemoveListener(UpdateCamera);
        }
        #endregion



        #region Interface Methods
        public void UpdateCamera() {
            if (!cockpitPosition) return;
            transform.position = cockpitPosition.position;
            transform.LookAt(lookAtTarget);
        }
        #endregion
    }
}
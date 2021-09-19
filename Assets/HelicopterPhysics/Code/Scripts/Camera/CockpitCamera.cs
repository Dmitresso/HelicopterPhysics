using UnityEngine;


namespace WheelApps {
    public class CockpitCamera : BaseCamera, IHelicopterCamera {
        #region Variables
        [Header("Cockpit Camera Properties")]
        public Vector3 offset = Vector3.zero;
        public float fov = 55f;
        
        private Vector3 startOffset;
        #endregion
        
        
        
        #region Builtin Methods
        private void OnEnable() {
            startOffset = transform.position - rb.position;
            updateEvent.AddListener(UpdateCamera);
        }


        private void OnDisable() {
            updateEvent.RemoveListener(UpdateCamera);
        }
        #endregion



        #region Interface Methods
        public void UpdateCamera() {
            transform.position = rb.position + startOffset;
            transform.LookAt(lookAtTarget);
        }
        #endregion
    }
}
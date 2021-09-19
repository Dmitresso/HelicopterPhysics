using UnityEngine;


namespace WheelApps {
    public class Camera : BaseCamera, IHelicopterCamera {
        #region Variables
        [Header("Helicopter Camera Properties")]
        public float height = 2f;
        public float distance = 2f;
        public float smoothSpeed = 0.35f;
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
            var transform = this.transform;
            var rbPosition = rb.position;
            
            targetPosition = rbPosition + -targetFlatForward * distance + Vector3.up * height;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref refVelocity, smoothSpeed);
            transform.LookAt(lookAtTarget);
        }
        #endregion
    }
}
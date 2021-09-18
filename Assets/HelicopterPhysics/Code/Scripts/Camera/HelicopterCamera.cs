using UnityEngine;


namespace WheelApps {
    public class HelicopterCamera : BaseHelicopterCamera, IHelicopterCamera {
        #region Variables
        [Header("Helicopter Camera Properties")]
        public float height = 2f;
        public float distance = 2f;
        public float smoothSpeed = 0.35f;
        #endregion


        
        #region Builtin Methods
        private void Start() {
            updateEvent.AddListener(UpdateCamera);
        }
        #endregion
        
        
        
        #region Interface Methods
        public void UpdateCamera() {
            var transform = this.transform;
            var rbPosition = rb.position;
            
            var flatForward = rb.transform.forward;
            flatForward.y = 0f;
            flatForward = flatForward.normalized;

            targetPosition = rbPosition + flatForward * distance + Vector3.up * height;

            transform.position = Vector3.SmoothDamp(rbPosition, targetPosition, ref refVelocity, smoothSpeed);
            transform.LookAt(lookAtTarget);
        }
        #endregion
    }
}
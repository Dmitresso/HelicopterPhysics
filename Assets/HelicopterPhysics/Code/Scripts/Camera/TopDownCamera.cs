using UnityEngine;


namespace WheelApps {
    public class TopDownCamera : BaseCamera, IHelicopterCamera {
        #region Variables
        [Header("Top Down Camera Properties")]
        public float height = 120f;
        public float distance = 80f;
        public float leadDistance = 0.25f;
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
            var targetPos = rb.position;
            targetPos.y = 0f;

            targetPosition = Vector3.back * - distance + Vector3.up * height;

            var lead = rb.velocity;
            lead.y = 0f;
            
            transform.position = targetPos + targetPosition;
            transform.LookAt(lookAtTarget.position + lead * leadDistance);
        }
        #endregion
    }
}
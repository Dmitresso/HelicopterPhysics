using UnityEngine;


namespace WheelApps {
    public class TopDownCamera : BaseCamera, IHelicopterCamera {
        #region Variables
        [Header("Top Down Camera Properties")]
        public float height = 120f;
        public float distance = 80f;
        public float leadDistance = 0.25f;
        public float smoothTime = 0.15f;

        private Vector3 finalPosition;
        private Vector3 finalLead;
        private Vector3 refLeadVelocity;
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

            finalPosition = Vector3.SmoothDamp(finalPosition, targetPos + targetPosition, ref refVelocity, smoothTime);
            transform.position = targetPos + targetPosition;

            finalLead = Vector3.SmoothDamp(finalLead, lead * leadDistance, ref refLeadVelocity, smoothTime);
            transform.LookAt(lookAtTarget.position + finalLead);
        }
        #endregion
    }
}
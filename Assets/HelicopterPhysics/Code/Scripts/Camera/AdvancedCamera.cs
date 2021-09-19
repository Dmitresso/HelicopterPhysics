using UnityEngine;


namespace WheelApps {
    public class AdvancedCamera : BaseCamera, IHelicopterCamera {
        #region Variables
        [Header("Advanced Camera Properties")]
        public float height = 4f;
        public float minDistance = 4f;
        public float maxDistance = 8f;
        public float catchUpModifier = 5f;
        #endregion



        #region Builtin Methods
        private void Start() {
            updateEvent.AddListener(UpdateCamera);
        }


        private void OnDisable() {
            updateEvent.RemoveListener(UpdateCamera);
        }
        #endregion



        #region Interface Methods
        public void UpdateCamera() {
            var targetDirection = transform.position - rb.position;
            targetDirection.y = 0f;
            var normalizedDirection = targetDirection.normalized;
            // Debug.DrawRay(rb.position, targetDirection, Color.green);
            
            targetPosition = rb.position + targetDirection;
            var currentMagnitude = targetDirection.magnitude;
            if (targetDirection.magnitude < minDistance) {
                var delta = minDistance - currentMagnitude;
                targetPosition += normalizedDirection * delta * catchUpModifier * Time.fixedDeltaTime;
            }
            if (targetDirection.magnitude > maxDistance) {
                var delta = currentMagnitude - maxDistance;
                targetPosition -= normalizedDirection * delta * catchUpModifier * Time.fixedDeltaTime;
            }
            
            
            transform.position = targetPosition + height * Vector3.up;
            transform.LookAt(lookAtTarget);
        }
        #endregion
    }
}
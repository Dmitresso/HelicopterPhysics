using UnityEngine;


namespace WheelApps {
    public class AdvancedCamera : BaseCamera, IHelicopterCamera {
        #region Variables
        [Header("Advanced Camera Properties")]
        public float height = 4f;
        public float minDistance = 4f;
        public float maxDistance = 8f;
        public float catchUpModifier = 5f;
        public float rotationSpeed = 5f;
        public float minOrientVelocity = 5f;
        
        
        private float finalAngle;
        private Vector3 targetDirection;
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
            var directionToTarget = transform.position - rb.position;
            directionToTarget.y = 0f;
            var normalizedDirection = directionToTarget.normalized;
            targetDirection = normalizedDirection;

            
            var angleToForward = Vector3.SignedAngle(normalizedDirection, targetFlatForward, Vector3.up);
            var targetAngle = 0f;
            if (rb.velocity.magnitude > minOrientVelocity) targetAngle = angleToForward * Time.fixedDeltaTime;
            finalAngle = Mathf.Lerp(finalAngle, targetAngle, rotationSpeed * Time.fixedDeltaTime);
            targetDirection = Quaternion.AngleAxis(finalAngle, Vector3.up) * targetDirection;
            
            
            targetPosition = rb.position + targetDirection * directionToTarget.magnitude;
            var currentMagnitude = directionToTarget.magnitude;
            if (currentMagnitude < minDistance) {
                var delta = minDistance - currentMagnitude;
                targetPosition += targetDirection * delta * catchUpModifier * Time.fixedDeltaTime;
            }
            if (currentMagnitude > maxDistance) {
                var delta = currentMagnitude - maxDistance;
                targetPosition -= targetDirection * delta * catchUpModifier * Time.fixedDeltaTime;
            }
            
            
            transform.position = targetPosition + height * Vector3.up;
            transform.LookAt(lookAtTarget);
        }
        #endregion
    }
}
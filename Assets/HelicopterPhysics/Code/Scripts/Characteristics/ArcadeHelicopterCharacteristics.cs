using UnityEngine;


namespace WheelApps {
    public class ArcadeHelicopterCharacteristics : HelicopterCharacteristics {
        #region Variables
        [Header("Arcade Properties")]
        public float bankAngle = 35f;
        public float bankSpeed = 4f;
        
        private float xRotation, yRotation, zRotation;
        private Quaternion finalRotation = Quaternion.identity;
        #endregion



        #region Builtin Methods
        #endregion


        #region Custom Methods
        protected override void HandleLift(Rigidbody rb, InputController input) {
            var liftForce = Physics.gravity.magnitude * rb.mass * Vector3.up;
            rb.AddForce(liftForce, ForceMode.Force);
            rb.AddForce(input.Throttle * maxLiftForce * Vector3.up, ForceMode.Acceleration);
        }

        
        protected override void HandleCyclic(Rigidbody rb, InputController input) {
            var forwardDirection = input.Cyclic.y * flatForward;
            var rightDirection = input.Cyclic.x * flatRight;
            var finalDirection = (forwardDirection + rightDirection).normalized;
            rb.AddForce(cyclicForce * finalDirection, ForceMode.Acceleration);

            xRotation = input.Cyclic.y * bankAngle;
            zRotation = -input.Cyclic.x * bankAngle;
        }


        protected override void HandlePedals(Rigidbody rb, InputController input) {
            yRotation += input.Pedal * tailForce;
        }


        protected override void AutoLevel(Rigidbody rb) {
            var targetRotation = Quaternion.Euler(xRotation, yRotation, zRotation);
            finalRotation = Quaternion.Slerp(finalRotation, targetRotation, Time.fixedDeltaTime * bankSpeed);
            rb.MoveRotation(finalRotation);
        }
        #endregion
    }
}
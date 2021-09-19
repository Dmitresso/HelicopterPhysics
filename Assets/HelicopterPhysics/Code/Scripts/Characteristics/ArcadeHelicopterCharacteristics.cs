using UnityEngine;


namespace WheelApps {
    public class ArcadeHelicopterCharacteristics : HelicopterCharacteristics {
        #region Variables
        private float xRotation;
        private float yRotation;
        private float zRotation;
        #endregion



        #region Builtin Methods
        #endregion


        #region Custom Methods
        protected override void HandleLift(Rigidbody rb, InputController input) {
            // base.HandleLift(rb, input);
            var liftForce = Physics.gravity.magnitude * rb.mass * transform.up;
            rb.AddForce(liftForce, ForceMode.Force);
            rb.AddForce(input.Throttle * maxLiftForce * Vector3.up, ForceMode.Acceleration);
        }

        
        protected override void HandleCyclic(Rigidbody rb, InputController input) {
            //base.HandleCyclic(rb, input);
            var forwardDirection = input.Cyclic.y * flatForward;
            var rightDirection = input.Cyclic.x * flatRight;
            var finalDirection = (forwardDirection + rightDirection).normalized;
            rb.AddForce(cyclicForce * finalDirection, ForceMode.Acceleration);
        }


        protected override void HandlePedals(Rigidbody rb, InputController input) {
            //base.HandlePedals(rb, input);
            yRotation += input.Pedal * tailForce;
            var targetRotation = Quaternion.Euler(0f, yRotation, 0f);
            rb.MoveRotation(targetRotation);
        }
        #endregion
    }
}
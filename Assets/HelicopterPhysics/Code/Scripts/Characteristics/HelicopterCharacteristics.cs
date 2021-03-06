using UnityEngine;


namespace WheelApps {
    public class HelicopterCharacteristics : MonoBehaviour {
        #region Variables

        [Header("Lift Properties")] public float maxLiftForce = 10f;
        public MainHelicopterRotor mainRotor;

        [Space] [Header("Tail Rotor Properties")]
        public float tailForce = 3f;

        [Space] [Header("Cyclic Properties")] public float cyclicForce = 2f;
        public float cyclicForceMultiplier = 10f;

        [Space] [Header("Auto Level Properties")]
        public float autoLevelForce = 2f;


        protected Vector3 flatForward, flatRight;
        protected float forwardDot, rightDot;

        #endregion



        #region Custom Methods

        public void UpdateCharacteristics(Rigidbody rb, InputController input) {
            HandleLift(rb, input);
            HandleCyclic(rb, input);
            HandlePedals(rb, input);
            CalculateAngles();
            AutoLevel(rb);
        }


        protected virtual void HandleLift(Rigidbody rb, InputController input) {
            if (!mainRotor) return;
            var liftForce = (Physics.gravity.magnitude + maxLiftForce) * rb.mass * transform.up;
            var normalizedRPM = mainRotor.CurrentRPM * 0.05f;
            // var finalForce = Mathf.Pow(normalizedRPM, 2f) * Mathf.Pow(input.StickyCollective, 2f) * liftForce;
            var finalForce = normalizedRPM * input.StickyCollective * liftForce * 0.002f;
            rb.AddForce(finalForce, ForceMode.Force);
        }


        protected virtual void HandleCyclic(Rigidbody rb, InputController input) {
            var cyclicZForce = -input.Cyclic.x * cyclicForce;
            rb.AddRelativeTorque(cyclicZForce * Vector3.forward, ForceMode.Acceleration);

            var cyclicXForce = input.Cyclic.y * cyclicForce;
            rb.AddRelativeTorque(cyclicXForce * Vector3.right, ForceMode.Acceleration);


            var forwardVector = flatForward * forwardDot;
            var rightVector = flatRight * rightDot;
            var finalCyclicForce = cyclicForce * cyclicForceMultiplier *
                                   Vector3.ClampMagnitude(forwardVector + rightVector, 1f);

            // Debug.DrawRay(transform.position, finalCyclicForce, Color.green);
 
            rb.AddForce(finalCyclicForce, ForceMode.Force);
        }


        protected virtual void HandlePedals(Rigidbody rb, InputController input) {
            rb.AddTorque(input.Pedal * tailForce * Vector3.up, ForceMode.Acceleration);
        }


        private void CalculateAngles() {
            var t = transform;

            flatForward = t.forward;
            flatForward.y = 0f;
            flatForward = flatForward.normalized;
            // Debug.DrawLine(transform.position, flatForward, Color.blue);

            flatRight = t.right;
            flatRight.y = 0f;
            flatRight = flatRight.normalized;
            // Debug.DrawLine(transform.position, flatRight, Color.red);

            forwardDot = Vector3.Dot(t.up, flatForward);
            rightDot = Vector3.Dot(t.right, flatRight);

            // Debug.Log($"FWD: {forwardDot.ToString()} - Right: {rightDot.ToString()}");
        }


        protected virtual void AutoLevel(Rigidbody rb) {
            var rightForce = -forwardDot * autoLevelForce;
            var forwardForce = rightDot * autoLevelForce;

            rb.AddRelativeTorque(rightForce * Vector3.right, ForceMode.Acceleration);
            rb.AddRelativeTorque(forwardForce * Vector3.forward, ForceMode.Acceleration);
        }

        #endregion
    }
}
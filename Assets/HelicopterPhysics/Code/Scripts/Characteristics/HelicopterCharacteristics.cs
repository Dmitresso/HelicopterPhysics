using UnityEngine;

namespace WheelApps {
    public class HelicopterCharacteristics : MonoBehaviour {
        #region Variables
        [Header("Lift Properties")]
        public float maxLiftForce = 10f;
        public MainHelicopterRotor mainRotor;

        [Space] [Header("Tail Rotor Properties")]
        public float tailForce = 2000f;

        [Space] [Header("Cyclic Properties")]
        public float cyclicForce = 2f;

        private Vector3 flatForward, flatRight;
        #endregion



        #region Builtin Methods
        private void Start() {
            
        }
        #endregion
        
        
        
        #region Custom Methods
        public void UpdateCharacteristics(Rigidbody rb, InputController input) {
            HandleLift(rb, input);
            HandleCyclic(rb, input);
            HandlePedals(rb, input);
            CalculateAngles();
            AutoLevel();
        }


        protected virtual void HandleLift(Rigidbody rb, InputController input) {
            if (!mainRotor) return;
            var liftForce = (Physics.gravity.magnitude + maxLiftForce) * rb.mass * transform.up;
            var normalizedRPM = mainRotor.CurrentRPM * 0.05f;
            var finalForce = Mathf.Pow(normalizedRPM, 2f) * Mathf.Pow(input.StickyCollective, 2f) * liftForce;
            rb.AddForce(finalForce, ForceMode.Force);
        }
        
        
        protected virtual void HandleCyclic(Rigidbody rb, InputController input) {
            var cyclicZForce = input.Cyclic.x * cyclicForce;
            rb.AddRelativeTorque(cyclicZForce * Vector3.forward, ForceMode.Acceleration);
            
            var cyclicXForce = -input.Cyclic.y * cyclicForce;
            rb.AddRelativeTorque(cyclicZForce * Vector3.right, ForceMode.Acceleration);
        }


        protected virtual void HandlePedals(Rigidbody rb, InputController input) {
            rb.AddForce(input.Pedal * tailForce * Vector3.up, ForceMode.Acceleration);
        }


        private void CalculateAngles() {
            flatForward = transform.forward;
            flatForward.y = 0f;
            flatForward = flatForward.normalized;
            //Debug.DrawLine(transform.position, flatForward, Color.blue);

            flatRight = transform.right;
            flatRight.y = 0f;
            flatRight = flatRight.normalized;
            //Debug.DrawLine(transform.position, flatRight, Color.red);
        }


        private void AutoLevel() {
            
        }
        #endregion
    }
}
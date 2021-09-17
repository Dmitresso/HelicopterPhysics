using UnityEngine;

namespace WheelApps {
    public class HelicopterCharacteristics : MonoBehaviour {
        #region Variables
        [Header("Lift Properties")]
        public float maxLiftForce = 10f;
        public MainHelicopterRotor mainRotor;
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
        }


        protected virtual void HandleLift(Rigidbody rb, InputController input) {
            if (!mainRotor) return;
            var liftForce = (Physics.gravity.magnitude + maxLiftForce) * rb.mass * transform.up;
            var normalizedRPM = mainRotor.CurrentRPM * 0.05f;
            var finalForce = Mathf.Pow(normalizedRPM, 2f) * Mathf.Pow(input.StickyCollective, 2f) * liftForce;
            rb.AddForce(finalForce, ForceMode.Force);
        }
        
        
        protected virtual void HandleCyclic(Rigidbody rb, InputController input) {
            // Debug.Log("CYCLIC");
        }


        protected virtual void HandlePedals(Rigidbody rb, InputController input) {
            // Debug.Log("PEDALS");
        }
        #endregion
    }
}
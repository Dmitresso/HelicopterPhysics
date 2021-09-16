using UnityEngine;

namespace WheelApps {
    public class HelicopterCharacteristics : MonoBehaviour {
        #region Variables
        #endregion


        #region Custom Methods
        public void UpdateCharacteristics(Rigidbody rb, InputController input) {
            HandleLift(rb, input);
            HandleCyclic(rb, input);
            HandlePedals(rb, input);
        }


        protected virtual void HandleLift(Rigidbody rb, InputController input) {
            var liftForce = transform.up * (Physics.gravity.magnitude * rb.mass);
            rb.AddForce(liftForce, ForceMode.Force);
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
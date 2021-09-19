using UnityEngine;

namespace WheelApps {
    public class ArcadeHelicopterCharacteristics : HelicopterCharacteristics {
        #region Variables
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
        }


        protected override void HandlePedals(Rigidbody rb, InputController input) {
            //base.HandlePedals(rb, input);
        }
        #endregion
    }
}
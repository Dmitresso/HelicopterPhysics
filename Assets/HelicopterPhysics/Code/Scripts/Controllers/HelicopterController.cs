using UnityEngine;


namespace WheelApps {
    [RequireComponent(typeof(InputController))]
    public class HelicopterController : BaseRBController {
        #region MyRegion
        [Header("Controller Properties")]
        public InputController input;
        #endregion



        #region Builtin Methods
        #endregion



        #region Custom Methods
        protected override void HandlePhysics() {
            if (!input) return;
            HandleEngines();
            HandleCharacteristics();
        }


        protected virtual void HandleEngines() {
            
        }


        protected virtual void HandleCharacteristics() {
            
        }
        #endregion
    }
}
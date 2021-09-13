using UnityEngine;


namespace WheelApps {
    [RequireComponent(typeof(InputController), typeof(KeyboardInput))]
    public class HelicopterController : BaseRBController {
        #region MyRegion
        //[Header("Controller Properties")]
        public InputController input;
        #endregion



        #region Builtin Methods
        private void Start() {
            input = GetComponent<InputController>();
        }
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
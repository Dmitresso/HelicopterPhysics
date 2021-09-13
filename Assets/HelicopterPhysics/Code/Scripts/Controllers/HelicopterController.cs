using System.Collections.Generic;
using UnityEngine;


namespace WheelApps {
    [RequireComponent(typeof(InputController))]
    public class HelicopterController : BaseRBController {
        #region MyRegion
        [Header("Helicopter Properties")]
        public List<HelicopterEngine> engines = new List<HelicopterEngine>();
        
        private InputController input;
        #endregion



        #region Builtin Methods
        private void Start() {
            base.Start();
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
            foreach (var engine in engines) engine.UpdateEngine(input.Throttle);
        }


        protected virtual void HandleCharacteristics() {
            
        }
        #endregion
    }
}
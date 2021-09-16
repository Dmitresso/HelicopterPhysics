using System.Collections.Generic;
using UnityEngine;


namespace WheelApps {
    [RequireComponent(typeof(InputController))]
    public class HelicopterController : BaseRBController {
        #region MyRegion
        [Header("Helicopter Properties")]
        public List<HelicopterEngine> engines = new List<HelicopterEngine>();

        [Header("Helicopter Rotors")]
        public RotorController rotorController;
        
        private InputController input;
        private HelicopterCharacteristics characteristics;
        #endregion



        #region Builtin Methods
        public override void Start() {
            base.Start();
            input = GetComponent<InputController>();
            characteristics = GetComponent<HelicopterCharacteristics>();
        }
        #endregion



        #region Custom Methods
        protected override void HandlePhysics() {
            if (!input) return;
            HandleEngines();
            HandleRotors();
            HandleCharacteristics();
        }


        protected virtual void HandleEngines() {
            foreach (var engine in engines) {
                var finalPower = engine.CurrentHP;
                engine.UpdateEngine(input.StickyThrottle);
            }
        }


        protected void HandleRotors() {
            if (!rotorController || engines.Count <= 0) return;
            rotorController.UpdateRotors(input, engines[0].CurrentRPM);
        }
        

        protected virtual void HandleCharacteristics() {
            if (characteristics) characteristics.UpdateCharacteristics(rb, input);
        }
        #endregion
    }
}
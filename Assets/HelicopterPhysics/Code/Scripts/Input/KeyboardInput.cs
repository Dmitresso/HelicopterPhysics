using UnityEngine;


namespace WheelApps {
    public class KeyboardInput : BaseHelicopterInput {
        #region Variables
        [Header("Keyboard Inputs")]
        private float throttle;
        public float collective;
        public float cyclic;
        public float pedal;
        #endregion



        #region Properties
        public float Throttle => throttle;
        public float Collective => collective;
        public float Cyclic => cyclic;
        public float Pedal => pedal;
        #endregion
        
        
        
        #region Builtin Methods
        #endregion



        #region Custom Methods
        protected override void HandleInputs() {
            base.HandleInputs();
            throttle = vertical;
            pedal = horizontal;
        }
        #endregion
    }
}
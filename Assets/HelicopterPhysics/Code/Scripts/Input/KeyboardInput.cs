using UnityEngine;


namespace WheelApps {
    public class KeyboardInput : BaseHelicopterInput {
        #region Variables
        [Header("Keyboard Inputs")]
        private float throttle;
        public float collective;
        public Vector2 cyclic = Vector2.zero;
        public float pedal;
        #endregion



        #region Properties
        public float Throttle => throttle;
        public float Collective => collective;
        public Vector2 Cyclic => cyclic;
        public float Pedal => pedal;
        #endregion
        
        
        
        #region Builtin Methods
        #endregion



        #region Custom Methods
        protected override void HandleInputs() {
            base.HandleInputs();
            HandleThrottle();
            HandleCollective();
            HandleCyclic();
            HandlePedal();
        }


        private void HandleThrottle() {
            
        }


        private void HandleCyclic() {
            cyclic.x = horizontal;
            cyclic.y = vertical;
        }
        

        private void HandleCollective() {
            
        }
        

        private void HandlePedal() {
            
        }
        #endregion
    }
}
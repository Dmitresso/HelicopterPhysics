using UnityEngine;


namespace WheelApps {
    public class KeyboardInput : BaseHelicopterInput {
        #region Variables
        [Header("Keyboard Inputs")]
        private float throttle;
        private float collective;
        private Vector2 cyclic = Vector2.zero;
        private float pedal;
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
            throttle = UnityEngine.Input.GetAxis(Input.Throttle);
        }


        private void HandleCyclic() {
            cyclic.x = horizontal;
            cyclic.y = vertical;
        }
        

        private void HandleCollective() {
            collective = UnityEngine.Input.GetAxis(Input.Collective);
        }
        

        private void HandlePedal() {
            pedal = UnityEngine.Input.GetAxis(Input.Pedal);
        }
        #endregion
    }
}
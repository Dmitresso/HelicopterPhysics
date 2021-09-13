using UnityEngine;


namespace WheelApps {
    public class KeyboardInput : BaseHelicopterInput {
        #region Variables
        [Header("Keyboard Inputs")]
        protected float throttle;
        protected float collective;
        protected Vector2 cyclic = Vector2.zero;
        protected float pedal;
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


        protected virtual void HandleThrottle() {
            throttle = UnityEngine.Input.GetAxis(Input.Throttle);
        }


        protected virtual void HandleCyclic() {
            cyclic.x = horizontal;
            cyclic.y = vertical;
        }
        

        protected virtual void HandleCollective() {
            collective = UnityEngine.Input.GetAxis(Input.Collective);
        }
        

        protected virtual void HandlePedal() {
            pedal = UnityEngine.Input.GetAxis(Input.Pedal);
        }
        #endregion
    }
}
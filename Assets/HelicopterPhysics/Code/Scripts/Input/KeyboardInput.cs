using UnityEngine;


namespace WheelApps {
    public class KeyboardInput : BaseHelicopterInput {
        #region Variables
        [Header("Keyboard Inputs")]
        protected float rawThrottle;
        protected float collective;
        protected Vector2 cyclic = Vector2.zero;
        protected float pedal;
        protected float stickyThrottle;
        #endregion



        #region Properties
        public float RawThrottle => rawThrottle;
        public float Collective => collective;
        public Vector2 Cyclic => cyclic;
        public float Pedal => pedal;
        public float StickyThrottle => stickyThrottle;
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
            HandleStickyThrottle();
            
            ClampInputs();
        }


        protected virtual void HandleThrottle() {
            rawThrottle = UnityEngine.Input.GetAxis(Input.Throttle);
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
        
        
        protected void ClampInputs() {
            rawThrottle = Mathf.Clamp(rawThrottle, -1f, 1f);
            collective = Mathf.Clamp(collective, -1f, 1f);
            cyclic = Vector2.ClampMagnitude(cyclic, 1f);
            pedal = Mathf.Clamp(pedal, -1f, 1f);
        }


        protected void HandleStickyThrottle() {
            stickyThrottle += rawThrottle * Time.deltaTime;
            stickyThrottle = Mathf.Clamp(stickyThrottle, 0f, 1f);
        }
        #endregion
    }
}
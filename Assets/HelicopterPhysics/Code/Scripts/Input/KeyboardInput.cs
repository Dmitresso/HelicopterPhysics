using UnityEngine;
using UnityEngine.Events;


namespace WheelApps {
    public class KeyboardInput : BaseHelicopterInput {
        #region Variables
        [Header("Camera Input Properties")]
        public KeyCode camButton = Input.cameraButton;
        #endregion



        #region Properties
        protected float rawThrottle;
        public float RawThrottle => rawThrottle;
        
        protected float collective;
        public float Collective => collective;
        
        protected Vector2 cyclic = Vector2.zero;
        public Vector2 Cyclic => cyclic;
        
        protected float pedal;
        public float Pedal => pedal;
        
        protected float stickyThrottle;
        public float StickyThrottle => stickyThrottle;
        
        protected float stickyCollective;
        public float StickyCollective => stickyCollective;

        protected bool cameraButton;
        public bool CameraButton => cameraButton;
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
            HandleStickyCollective();
            HandleCameraButton();
            
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


        protected virtual void HandleCameraButton() {
            cameraButton = UnityEngine.Input.GetKeyDown(camButton);
        }

        
        protected void HandleStickyThrottle() {
            stickyThrottle += rawThrottle * Time.deltaTime;
            stickyThrottle = Mathf.Clamp(stickyThrottle, 0f, 1f);
        }

        
        protected void HandleStickyCollective() {
            stickyCollective += collective * Time.deltaTime;
            stickyCollective = Mathf.Clamp01(stickyCollective);
        }

        
        protected void ClampInputs() {
            rawThrottle = Mathf.Clamp(rawThrottle, -1f, 1f);
            collective = Mathf.Clamp(collective, -1f, 1f);
            cyclic = Vector2.ClampMagnitude(cyclic, 1f);
            pedal = Mathf.Clamp(pedal, -1f, 1f);
        }
        #endregion
    }
}
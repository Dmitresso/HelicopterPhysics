using UnityEngine;
using UnityEngine.Events;


namespace WheelApps {
    public enum InputType {
        Keyboard,
        Xbox,
        Mobile
    }
    
    
    [RequireComponent(typeof(KeyboardInput), typeof(XboxInput))]
    public class InputController : MonoBehaviour {
        #region Variables
        [Header("Input Properties")]        
        public InputType inputType = InputType.Keyboard;

        [Header("Input Events")]
        public UnityEvent onCameraButtonPressed = new UnityEvent();
        public UnityEvent onHelpButtonPressed = new UnityEvent();

        
        
        private KeyboardInput keyboardInput;
        private XboxInput xboxInput;
        #endregion



        #region Properties
        private float throttle;
        public float Throttle => throttle;
        
        private float collective;        
        public float Collective => collective;
        
        private Vector2 cyclic;        
        public Vector2 Cyclic => cyclic;
        
        private float pedal;        
        public float Pedal => pedal;
        
        private float stickyThrottle;        
        public float StickyThrottle => stickyThrottle;
        
        private float stickyCollective;        
        public float StickyCollective => stickyCollective;

        private bool cameraButton;
        public bool CameraButton => cameraButton;
        
        private bool fireButton;
        public bool FireButton => fireButton;

        private bool helpButton;
        public bool HelpButton => helpButton;
        #endregion
        
        

        #region Builtin Methods
        private void Start() {
            keyboardInput = GetComponent<KeyboardInput>();
            xboxInput = GetComponent<XboxInput>();
            if (keyboardInput && xboxInput) SetInput(inputType);
        }


        private void Update() {
            switch (inputType) {
                case InputType.Keyboard:
                    throttle = keyboardInput.RawThrottle;
                    collective = keyboardInput.Collective;
                    cyclic = keyboardInput.Cyclic;
                    pedal = keyboardInput.Pedal;
                    stickyThrottle = keyboardInput.StickyThrottle; 
                    stickyCollective = keyboardInput.StickyCollective;
                    cameraButton = keyboardInput.CameraButton;
                    fireButton = keyboardInput.FireButton;
                    helpButton = keyboardInput.HelpButton;
                    break;
                case InputType.Xbox:
                    throttle = xboxInput.RawThrottle;
                    collective = xboxInput.Collective;
                    cyclic = xboxInput.Cyclic;
                    pedal = xboxInput.Pedal;
                    stickyThrottle = xboxInput.StickyThrottle;
                    stickyCollective = xboxInput.StickyCollective;
                    cameraButton = xboxInput.CameraButton;
                    fireButton = xboxInput.FireButton;
                    helpButton = xboxInput.HelpButton;
                    break;
                case InputType.Mobile:
                    break;
            }

            if (cameraButton) onCameraButtonPressed?.Invoke();
            if (helpButton) onHelpButtonPressed?.Invoke();
        }
        #endregion



        #region Custom Methods
        private void SetInput(InputType type) {
            inputType = type;
            switch (type) {
                case InputType.Keyboard:
                    keyboardInput.enabled = true;
                    xboxInput.enabled = false;
                    break;
                case InputType.Xbox:
                    xboxInput.enabled = true;
                    keyboardInput.enabled = false;
                    break;
                case InputType.Mobile:
                    break;
            }
        }
        #endregion
    }
}
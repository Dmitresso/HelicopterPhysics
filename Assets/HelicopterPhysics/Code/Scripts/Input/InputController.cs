using UnityEngine;


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

        private KeyboardInput keyboardInput;
        private XboxInput xboxInput;

        private float throttle;
        private float collective;
        private Vector2 cyclic;
        private float pedal;
        #endregion



        #region Properties
        public float Throttle => throttle;
        public float Collective => collective;
        public Vector2 Cyclic => cyclic;
        public float Pedal => pedal;
        #endregion
        
        

        #region Builtin Methods
        private void Start() {
            keyboardInput = GetComponent<KeyboardInput>();
            xboxInput = GetComponent<XboxInput>();
            //if (keyboardInput && xboxInput) SetInput(inputType);
        }


        private void Update() {
            switch (inputType) {
                case InputType.Keyboard:
                    throttle = keyboardInput.Throttle;
                    collective = keyboardInput.Collective;
                    cyclic = keyboardInput.Cyclic;
                    pedal = keyboardInput.Pedal;
                    break;
                case InputType.Xbox:
                    throttle = xboxInput.Throttle;
                    collective = xboxInput.Collective;
                    cyclic = xboxInput.Cyclic;
                    pedal = xboxInput.Pedal;
                    break;
                case InputType.Mobile:
                    break;
            }
        }
        #endregion



        #region Custom Methods
        private void SetInput(InputType type) {
            switch (type) {
                case InputType.Keyboard:
                    keyboardInput.enabled = true;
                    xboxInput.enabled = false;
                    break;
                case InputType.Xbox:
                    xboxInput.enabled = true;
                    keyboardInput.enabled = false;
                    break;
            }
        }
        #endregion
    }
}
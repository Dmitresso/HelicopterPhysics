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
        #endregion



        #region Builtin Methods
        private void Start() {
            keyboardInput = GetComponent<KeyboardInput>();
            xboxInput = GetComponent<XboxInput>();
            if (keyboardInput && xboxInput) SetInput(inputType);
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
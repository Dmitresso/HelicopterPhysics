using UnityEngine;

namespace WheelApps {
    public enum InputType {
        Keyboard,
        Xbox,
        Mobile
    }
    
    public class InputController : MonoBehaviour {
        #region Variables
        public InputType inputType = InputType.Keyboard;

        [Header("Input Components")]
        public KeyboardInput keyboardInput;
        public XboxInput xboxInput;
        #endregion



        #region Builtin Methods
        private void Start() {
            SetInput(inputType);
        }
        #endregion



        #region Custom Methods
        private void SetInput(InputType type) {
            switch (type) {
                case InputType.Keyboard:
                    if (keyboardInput) {
                        keyboardInput.enabled = true;
                        xboxInput.enabled = false;
                    }
                    break;
                case InputType.Xbox:
                    if (xboxInput) {
                        xboxInput.enabled = true;
                        keyboardInput.enabled = false;
                    }
                    break;
            }
        }
        #endregion
    }
}
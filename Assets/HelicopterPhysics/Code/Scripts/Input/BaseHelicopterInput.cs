using UnityEngine;


namespace WheelApps {
    public class BaseHelicopterInput : MonoBehaviour {
        #region Variables
        [Header("Base Input Properties")]
        protected float vertical;
        protected float horizontal;
        #endregion



        #region Builtin Methods
        private void Update() {
            HandleInputs();
        }
        #endregion



        #region Custom Methods
        protected virtual void HandleInputs() {
            horizontal = UnityEngine.Input.GetAxis(Input.Horizontal);
            vertical = UnityEngine.Input.GetAxis(Input.Vertical);
        }
        #endregion
    }
}
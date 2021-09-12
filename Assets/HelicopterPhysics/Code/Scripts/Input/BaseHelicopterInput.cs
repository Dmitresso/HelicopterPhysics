using UnityEngine;


namespace WheelApps {
    public class BaseHelicopterInput : MonoBehaviour {
        #region Variables
        [Header("Base Input Properties")]
        protected float vertical;
        protected float horizontal;
        #endregion



        #region Constants
        protected const string H = "Horizontal";
        protected const string V = "Vertical";
        #endregion


        
        #region Builtin Methods
        private void Update() {
            HandleInputs();
        }
        #endregion



        #region Custom Methods
        protected virtual void HandleInputs() {
            horizontal = Input.GetAxis(H);
            vertical = Input.GetAxis(V);
        }
        #endregion
    }
}
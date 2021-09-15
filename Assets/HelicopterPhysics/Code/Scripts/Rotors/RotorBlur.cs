using UnityEngine;

namespace WheelApps {
    public class RotorBlur : MonoBehaviour, IHelicopterRotor {
        #region Variables
        [Header("Rotor Blur Properties")]
        public GameObject lRotor;
        public GameObject rRotor;
        public GameObject blurGeo;
        #endregion
        
        
        
        #region Interface Methods
        public void UpdateRotor(float dps, InputController input) {
        }
        #endregion

    }
}
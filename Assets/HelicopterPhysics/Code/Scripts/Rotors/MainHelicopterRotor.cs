using UnityEngine;


namespace WheelApps {
    public class MainHelicopterRotor : MonoBehaviour, IHelicopterRotor {
        #region Variables
        [Header("Main Rotor Properties")]
        public Transform lRotor;
        public Transform rRotor;
        public float maxPitch = 35f;
        #endregion



        #region Builtin Methods
        #endregion



        #region Interface Methods
        public void UpdateRotor(float dps, InputController input) {
            transform.Rotate(Vector3.up, dps);

            if (!lRotor || !rRotor) return;
            lRotor.localRotation = Quaternion.Euler(input.Collective * maxPitch, 0f, 0f);
            rRotor.localRotation = Quaternion.Euler(- input.Collective * maxPitch, 0f, 0f);
        }        
        #endregion


        
        #region Custom Methods
        #endregion
    }
}
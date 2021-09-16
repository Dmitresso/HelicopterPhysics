using UnityEngine;


namespace WheelApps {
    public class MainHelicopterRotor : MonoBehaviour, IHelicopterRotor {
        #region Variables
        [Header("Main Rotor Properties")]
        public Transform lRotor;
        public Transform rRotor;
        public float maxPitch = 35f;
        
        private float currentRPM;
        #endregion



        #region Properties
        public float CurrentRPM => currentRPM;
        #endregion



        #region Interface Methods
        public void UpdateRotor(float dps, InputController input) {
            //currentRPM = dps / 360 * 60f;
            currentRPM = dps * 6f;
            
            transform.Rotate(Vector3.up, dps * Time.deltaTime);

            if (!lRotor || !rRotor) return;
            lRotor.localRotation = Quaternion.Euler(-input.StickyCollective * maxPitch, 0f, 0f);
            rRotor.localRotation = Quaternion.Euler(input.StickyCollective * maxPitch, 0f, 0f);
        }        
        #endregion


        
        #region Custom Methods
        #endregion
    }
}
using UnityEngine;


namespace WheelApps {
    public class TailHelicopterRotor : MonoBehaviour, IHelicopterRotor {
        #region Variables
        [Header("Tail Rotor Properties")]
        public float rotationSpeedModifier = 1.5f;
        public Transform lRotor;
        public Transform rRotor;
        public float maxPitch = 45f;
        #endregion



        #region Builtin Methods
        #endregion



        #region Interface Methods
        public void UpdateRotor(float dps, InputController input) {
            transform.Rotate(Vector3.right, dps * rotationSpeedModifier * Time.deltaTime);
            
            if (!lRotor || !rRotor) return;
            lRotor.localRotation = Quaternion.Euler(0f, input.Pedal * maxPitch, 0f);
            rRotor.localRotation = Quaternion.Euler(0f, - input.Pedal * maxPitch, 0f);
        }        
        #endregion


        
        #region Custom Methods
        #endregion
    }
}
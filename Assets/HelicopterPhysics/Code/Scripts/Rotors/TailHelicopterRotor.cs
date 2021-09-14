using UnityEngine;


namespace WheelApps {
    public class TailHelicopterRotor : MonoBehaviour, IHelicopterRotor {
        #region Variables
        [Header("Tail Rotor Properties")]
        public float rotationSpeedModifier = 1.5f;
        #endregion



        #region Builtin Methods
        #endregion



        #region Interface Methods
        public void UpdateRotor(float dps) {
            transform.Rotate(Vector3.right, dps * rotationSpeedModifier);
        }        
        #endregion


        
        #region Custom Methods
        #endregion
    }
}
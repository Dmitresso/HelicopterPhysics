using UnityEngine;


namespace WheelApps {
    public class MainHelicopterRotor : MonoBehaviour, IHelicopterRotor {
        #region Variables
        #endregion



        #region Builtin Methods
        #endregion



        #region Interface Methods
        public void UpdateRotor(float dps) {
            transform.Rotate(Vector3.up, dps);
        }        
        #endregion


        
        #region Custom Methods
        #endregion
    }
}
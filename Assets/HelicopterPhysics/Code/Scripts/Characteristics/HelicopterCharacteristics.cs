using UnityEngine;

namespace WheelApps {
    public class HelicopterCharacteristics : MonoBehaviour {
        #region Variables
        #endregion


        #region Custom Methods
        public void UpdateCharacteristics() {
            HandleLift();
            HandleCyclic();
            HandlePedals();
        }


        protected virtual void HandleLift() {
            Debug.Log("LIFT");
        }
        
        
        protected virtual void HandleCyclic() {
            Debug.Log("CYCLIC");
        }


        protected virtual void HandlePedals() {
            Debug.Log("PEDALS");
        }
        #endregion
    }
}
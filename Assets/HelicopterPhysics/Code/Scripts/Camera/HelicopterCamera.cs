using UnityEngine;


namespace WheelApps {
    public class HelicopterCamera : MonoBehaviour, IHelicopterCamera {
        #region Variables
        [Header("Camera Properties")]
        public Rigidbody rb;
        public float height = 2f;
        public float distance = 2f;
        #endregion


        
        #region Builtin Methods
        private void FixedUpdate() {
            if (rb) UpdateCamera();
        }
        #endregion
        
        
        
        #region Interface Methods
        public void UpdateCamera() {
            
        }
        #endregion
    }
}
using UnityEngine;


namespace WheelApps {
    public class TopDownCamera : BaseCamera, IHelicopterCamera {
        #region Variables
        [Header("Top Down Camera Properties")]
        public float height = 4f;
        public float distance = 4f;
        #endregion



        #region Builtin Methods
        private void OnEnable() {
            updateEvent.AddListener(UpdateCamera);
        }


        private void OnDisable() {
            updateEvent.RemoveListener(UpdateCamera);
        }
        #endregion
        
        

        #region Interface Methods
        public void UpdateCamera() {
            
        }
        #endregion
    }
}
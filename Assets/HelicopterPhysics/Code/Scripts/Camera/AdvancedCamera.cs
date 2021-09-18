namespace WheelApps {
    public class AdvancedCamera : BaseCamera, IHelicopterCamera {
        #region Variables
        #endregion



        #region Builtin Methods
        private void Start() {
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
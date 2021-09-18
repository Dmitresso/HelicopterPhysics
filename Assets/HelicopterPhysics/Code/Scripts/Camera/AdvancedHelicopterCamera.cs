namespace WheelApps {
    public class AdvancedHelicopterCamera : BaseHelicopterCamera, IHelicopterCamera {
        #region Variables
        #endregion



        #region Builtin Methods
        private void Start() {
            updateEvent.AddListener(UpdateCamera);
        }
        #endregion



        #region Interface Methods
        public void UpdateCamera() {
            
        }
        #endregion
    }
}
namespace WheelApps {
    public class XboxInput : KeyboardInput {
        #region Variables
        #endregion
        

        
        #region Builtin Methods
        #endregion

        

        #region Custom Methods
        protected override void HandleThrottle() {
            base.HandleThrottle();
        }


        protected override void HandleCollective() {
            base.HandleCollective();
        }


        protected override void HandleCyclic() {
            base.HandleCyclic();
        }


        protected override void HandlePedal() {
            base.HandlePedal();
        }
        #endregion
    }
}
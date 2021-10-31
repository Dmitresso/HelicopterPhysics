namespace WheelApps {
    public class XboxInput : KeyboardInput {
        #region Custom Methods
        protected override void HandleThrottle() {
            rawThrottle = UnityEngine.Input.GetAxis(Input.XboxThrottleUp) -
                       UnityEngine.Input.GetAxis(Input.XboxThrottleDown);
        }


        protected override void HandleCollective() {
            collective = UnityEngine.Input.GetAxis(Input.XboxCollective);
        }


        protected override void HandleCyclic() {
            cyclic.x = UnityEngine.Input.GetAxis(Input.XboxCyclicH);
            cyclic.y = UnityEngine.Input.GetAxis(Input.XboxCyclicV);
        }


        protected override void HandlePedal() {
            pedal = UnityEngine.Input.GetAxis(Input.XboxPedal);
        }
        
        
        protected override void HandleCameraButton() {
            cameraButtonB = UnityEngine.Input.GetButtonDown(Input.XboxCameraButton);
        }


        protected override void HandleFireButton() {
            fireButtonB = UnityEngine.Input.GetButtonDown(Input.XboxFireButton);
        }
        #endregion
    }
}
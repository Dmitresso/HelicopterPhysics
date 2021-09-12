using UnityEngine;


public class Torque : BaseRBController {
    #region Varaibles
    public float torqueSpeed = 2f;
    public Vector3 rotationDirection = new Vector3(0f, 1f, 0f);
    #endregion
    
    
    
    #region Custom Methods
    protected override void HandlePhysics() {
        rb.AddTorque(rotationDirection * torqueSpeed);
    }
    #endregion
}
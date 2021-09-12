using UnityEngine;


public class Drag : BaseRBController {
    #region Variables
    [Header("Drag Properties")]
    public float dragFactor = 0.05f;
    #endregion

    

    #region Custom Methods
    protected override void HandlePhysics() {
		if (!rb) return;
		var currentSpeed = rb.velocity.magnitude;
		var finalDrag = currentSpeed * dragFactor;
		rb.drag = finalDrag;		
	}
    #endregion
}
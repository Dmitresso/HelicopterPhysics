using UnityEngine;


public class Drag : MonoBehaviour {
    #region Variables
    [Header("Drag Properties")]
    public float dragFactor = 0.05f;

    private Rigidbody rb;
    #endregion

    

    #region Builting Methods
    private void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
    
	private void FixedUpdate () {
		if (!rb) return;
		var currentSpeed = rb.velocity.magnitude;
		var finalDrag = currentSpeed * dragFactor;
		rb.drag = finalDrag;
	}
    #endregion
}
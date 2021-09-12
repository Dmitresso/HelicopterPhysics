using UnityEngine;


public class Torque : MonoBehaviour {
    #region Varaibles
    public float torqueSpeed = 2f;
    public Vector3 rotationDirection = new Vector3(0f, 1f, 0f);

    private Rigidbody rb;
    #endregion



    #region Builtin Methods
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }


    private void Update() {
        if (rb) HandlePhysics(rotationDirection, torqueSpeed);
    }

    #endregion
    
    
    
    #region Custom Methods
    protected void HandlePhysics(Vector3 torque, float speed) {
        rb.AddTorque(torque * speed);
    }
    #endregion
}
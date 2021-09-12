using System;
using UnityEngine;
using IndiePixel;


public class Forces : MonoBehaviour {
    #region Variables
    public float maxSpeed = 1f;
    public Vector3 movementDirection = new Vector3(0f, 0f, 1f);

    private Rigidbody rb;
    #endregion


    
    #region Builtin Methods
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate() {
        if (rb) HandlePhysics(movementDirection, maxSpeed);
    }
    #endregion
    
    
    
    #region Custom Methods
    protected void HandlePhysics(Vector3 direction, float speed) {
        rb.AddForce(direction * speed);
    }
    #endregion
}
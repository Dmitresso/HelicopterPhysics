using UnityEngine;


public class Weight : MonoBehaviour {
    #region Variables
    [Header("Weight Properties")]
    public float weightInLbs = 10f;
    public float weight;

    private Rigidbody rb;
    #endregion


    
    #region Constants
    const float lbsToKg = 0.454f;
    const float kgToLbs = 2.205f;
    #endregion
    
    
    
    #region Builtin Methods
    private void Start () {
        var finalKG = weightInLbs * lbsToKg;
        weight = finalKG;
        rb = GetComponent<Rigidbody>();
        if (rb) rb.mass = finalKG;
    }
    #endregion
}
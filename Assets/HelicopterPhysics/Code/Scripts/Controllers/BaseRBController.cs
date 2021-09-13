using UnityEngine;


namespace WheelApps {
    [RequireComponent(typeof(Rigidbody))]
    public class BaseRBController : MonoBehaviour {
        #region Variables
        [Header("Base Properties")]
        public float weightInLbs = 10f;
        public Transform com;
    
    
        const float lbsToKg = 0.454f;
        const float kgToLbs = 2.205f;
    
        protected Rigidbody rb;
        protected float weight;
        #endregion
    
        
    
        #region BuiltIn Methods
        public virtual void Start() {
            var finalKG = weightInLbs * lbsToKg;
            weight = finalKG;
            rb = GetComponent<Rigidbody>();
            if(rb) rb.mass = weight;
            
        }
    
    
        void FixedUpdate() {
            if (rb) HandlePhysics();
        }
        #endregion
    
        
    
        #region Custom Methods
        protected virtual void HandlePhysics() { }
        #endregion
    }
}
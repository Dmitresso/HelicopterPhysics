using UnityEngine;


namespace WheelApps {
    [RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
    public class BaseProjectile : MonoBehaviour {
        #region Variables
        [Header("Base Projetile Properties")]
        public float speed = 200f;
        public float damage = 10f;

        protected Rigidbody rb;
        protected SphereCollider collider;
        #endregion



        #region Builtin Methods
        private void Start() {
            rb = GetComponent<Rigidbody>();
            collider = GetComponent<SphereCollider>();
            
            if (rb) FireProjectile();
        }
        #endregion



        #region Custom Methods
        public virtual void FireProjectile() {
            rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        }
        #endregion
    }
}
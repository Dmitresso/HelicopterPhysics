using System;
using UnityEngine;


namespace WheelApps {
    [RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
    public class BaseProjectile : MonoBehaviour, IShootable {
        #region Variables
        [Header("Base Projetile Properties")]
        public float speed = 200f;
        public float damage = 10f;

        protected Rigidbody rb;
        protected SphereCollider collider;
        #endregion

        

        #region Builtin Methods
        private void Awake() {
            rb = GetComponent<Rigidbody>();
            collider = GetComponent<SphereCollider>();
        }


        private void OnEnable() {
            if (rb) FireProjectile();
        }


        private void OnDisable() {
            if (rb) rb.velocity = Vector3.zero;
        }
        #endregion



        #region Custom Methods
        public void FireProjectile() {
            rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        }
        #endregion
    }
}
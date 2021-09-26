using UnityEngine;


namespace WheelApps {
    public class GatlingGunWeapon : RapidFireWeapon {
        #region Variables
        [Header("Gatling Gun Properties")]
        public Transform barrelGO;
        public float rotationSpeed = 15f;
        public float slowDownSpeed = 5f;

        private float lastRotationSpeed;
        #endregion



        #region Builtin Methods
        private void Update() {
            if (barrelGO) {
                lastRotationSpeed -= slowDownSpeed * Time.deltaTime;
                lastRotationSpeed = Mathf.Clamp(lastRotationSpeed, 0f, rotationSpeed);
                barrelGO.Rotate(Vector3.up, lastRotationSpeed);
            }
        }
        #endregion
        
        
        

        #region Override Methods
        public override void FireWeapon() {
            base.FireWeapon();

            if (barrelGO) {
                barrelGO.Rotate(Vector3.up, rotationSpeed);
                lastRotationSpeed = rotationSpeed;
            }

        }
        #endregion
    }
}
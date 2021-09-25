using UnityEngine;

namespace WheelApps {
    public class GatlingGunWeapon : RapidFireWeapon {
        #region Variables
        [Header("Gatling Gun Properties")]
        public Transform barrelGO;

        public float rotationSpeed = 10f;

        #endregion



        #region Override Methods
        public override void FireWeapon() {
            base.FireWeapon();
            
        }
        #endregion
    }
}
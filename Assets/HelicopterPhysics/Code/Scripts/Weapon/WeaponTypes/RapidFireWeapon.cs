using UnityEngine;


namespace WheelApps {
    [RequireComponent(typeof(AdvancedProjectilePool))]
    public class RapidFireWeapon : BaseWeapon {
        #region Variables
        [Header("Rapid Fire Properties")]
        public float fireRate = 0.15f;
        public float lastFireTime;
        #endregion


        
        #region Builtin Methods
        
        #endregion



        #region Override Methods
        public override void FireWeapon() {
            if (Time.time >= lastFireTime + fireRate) {
                Fire();
                lastFireTime = Time.time;
            }
        }
        #endregion
    }
}
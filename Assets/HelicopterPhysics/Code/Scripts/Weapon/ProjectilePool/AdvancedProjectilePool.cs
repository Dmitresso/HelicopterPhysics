using UnityEngine;


namespace WheelApps {
    public class AdvancedProjectilePool : ProjectilePool {
        #region Variables
        [Tooltip("Calculate pool size automatically according to \"utilizeDistance\", \"projectileSpeed\" and \"weaponFireRate\" values. True by default.")]
        public bool calculateOptimalPoolSize = true;

        private RapidFireWeapon weapon;
        #endregion



        #region Builtin Methods
        private void Start() {
            helicopter = transform.root;
            weapon = GetComponent<RapidFireWeapon>();
            var projectile = pooledGO.GetComponent<BaseProjectile>();

            if (calculateOptimalPoolSize) {
                size = CalculatePoolSize(utilizeDistance, projectile.speed, weapon.fireRate);
            }
            FillPool(size, pooledGO, parentGO);
        }
        #endregion



        #region Custom Methods
        private int CalculatePoolSize(float utilizeDistance, float projectileSpeed, float weaponFireRate) {
            return Mathf.RoundToInt(utilizeDistance / projectileSpeed / weaponFireRate) + 1;
        }
        #endregion
    }
}
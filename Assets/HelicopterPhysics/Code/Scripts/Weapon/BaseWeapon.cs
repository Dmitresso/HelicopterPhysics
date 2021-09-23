using UnityEngine;


namespace WheelApps {
    [RequireComponent(typeof(AudioSource))]
    public class BaseWeapon : MonoBehaviour, IWeapon {
        #region Variables
        [Header("Base Weapon Properties")]
        public Transform muzzlePosition;
        public GameObject projectile;
        public int maxAmmoCount = 100;
        [Space(5)]
        public GameObject muzzleFlash;
        
        protected AudioSource audioSource;
        protected int currentAmmoCount;

        #endregion



        #region Builtin Methods
        private void Start() {
            currentAmmoCount = maxAmmoCount;
        }
        #endregion

        
        
        #region Interface Methods
        public void Fire() {
            if (currentAmmoCount != 0) {
                HandleProjectile();
                HandleAudio();
                HandleVFX();

                currentAmmoCount--;
                currentAmmoCount = Mathf.Clamp(currentAmmoCount, 0, maxAmmoCount);
            }
            else Reload();
        }

        
        public void Reload() {
            currentAmmoCount = maxAmmoCount;
        }
        #endregion
        


        #region Custom Methods
        protected virtual void HandleProjectile() {
            if (!projectile) return;
            
        }


        protected virtual void HandleAudio() {
            if (!audioSource) return;
            
        }


        protected virtual void HandleVFX() {
            if (!muzzleFlash) return;
            
        }
        #endregion
    }
}
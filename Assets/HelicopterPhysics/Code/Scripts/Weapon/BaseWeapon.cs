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
        public ParticleSystem muzzleFlash;
        public AudioClip fireClip;

        protected ProjectilePool projectilePool;
        protected AudioSource audioSource;
        protected int currentAmmoCount;
        #endregion



        #region Builtin Methods
        private void Start() {
            projectilePool = GetComponent<ProjectilePool>();
            audioSource = GetComponent<AudioSource>();
            currentAmmoCount = maxAmmoCount;
        }
        #endregion

        
        
        #region Interface Methods
        public virtual void FireWeapon() {
            Fire();
        }

        
        public void Reload() {
            currentAmmoCount = maxAmmoCount;
        }
        #endregion
        


        #region Custom Methods
        protected void Fire() {
            if (currentAmmoCount != 0) {
                HandleProjectile();
                HandleAudio();
                HandleVFX();

                currentAmmoCount--;
                currentAmmoCount = Mathf.Clamp(currentAmmoCount, 0, maxAmmoCount);
            }
            else Reload();
        }
        
        
        protected virtual void HandleProjectile() {
            projectilePool.GetPooledObject();
            //if (projectile) Instantiate(projectile, muzzlePosition.position, Quaternion.LookRotation(muzzlePosition.forward));
        }


        protected virtual void HandleAudio() {
            if (audioSource && fireClip) audioSource.PlayOneShot(fireClip);
        }


        protected virtual void HandleVFX() {
            if (muzzleFlash) muzzleFlash.Play();
            
        }
        #endregion
    }
}
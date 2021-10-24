using System.Collections;
using UnityEngine;


namespace WheelApps {
    public class ProjectilePool : ObjectPool {
        #region Variables
        public float utilizeDistance = 100f;


        private int index;
        private BaseWeapon weapon;
        private Transform helicopter;
        private GameObject expandGO;
        #endregion



        #region Builtin Methods
        private void Start() {
            helicopter = transform.root;
            weapon = GetComponent<BaseWeapon>();
            
            FillPool(size, pooledGO, parentGO);
        }
        
        
        private void OnValidate() {
            if (pooledGO == null) return;
            if (pooledGO.GetComponent<BaseProjectile>() == null) {
                Debug.Log("\"Pooled Game Object\" must have \"BaseProjectile\" component.");
                pooledGO = null;
            }
        }
        #endregion


        #region Custom Methods
        public override IEnumerator Utilize(GameObject projectile) {
            yield return new WaitUntil(() => Vector3.Distance(helicopter.position, projectile.transform.position) > utilizeDistance);
            projectile.transform.SetPositionAndRotation(weapon.muzzlePosition.position, weapon.muzzlePosition.rotation);
            projectile.gameObject.SetActive(false);
        }
        #endregion
    }
}
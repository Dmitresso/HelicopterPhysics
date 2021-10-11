using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;


namespace WheelApps {
    public class ProjectileManager : MonoBehaviour {
        #region Variables
        public int poolSize = 10;
        public float utilizeDistance = 100f;

        private List<GameObject> projectilesPool = new List<GameObject>();
        private int index;
        private BaseWeapon weapon;
        private Transform helicopter;
        private GameObject expandGO;
        #endregion



        #region Builtin Methods
        private void Start() {
            helicopter = transform.root;
            weapon = GetComponent<BaseWeapon>();
            
            expandGO = new GameObject($"{weapon.name}_projectiles");
            expandGO.transform.SetParent(weapon.muzzlePosition.transform);
            expandGO.transform.SetPositionAndRotation(weapon.muzzlePosition.position, weapon.muzzlePosition.rotation);
            
            if (projectilesPool.Count == 0) {
                if (weapon.projectile == null) return;
                
                for (var i = 0; i < poolSize; i++) {
                    var projectile = Instantiate(weapon.projectile, expandGO.transform.position, Quaternion.LookRotation(expandGO.transform.forward));
                    projectile.transform.SetParent(expandGO.transform);
                    projectilesPool.Add(projectile);
                    projectile.SetActive(false);
                }
            }
        }
        #endregion


        #region Custom Methods
        public void Instantiate() {
            if (projectilesPool.Count < 0) return;
            var currentProjectile = projectilesPool[index];
            currentProjectile.gameObject.SetActive(true);
            StartCoroutine(Utilize(currentProjectile));
            index++;
            if (index == projectilesPool.Count) {
                // bad logic, rewrite
                if (projectilesPool[0].activeSelf) {
                    var projectile = Instantiate(weapon.projectile, expandGO.transform.position, Quaternion.LookRotation(expandGO.transform.forward));
                    projectile.transform.SetParent(expandGO.transform);
                    projectilesPool.Add(projectile);
                }
                else index = 0;
            }
        }


        private IEnumerator Utilize(GameObject projectile) {
            yield return new WaitUntil(() => Vector3.Distance(helicopter.position, projectile.transform.position) > utilizeDistance);
            projectile.gameObject.SetActive(false);
            projectile.transform.SetPositionAndRotation(weapon.muzzlePosition.position, weapon.muzzlePosition.rotation);
        }
        #endregion
    }
}
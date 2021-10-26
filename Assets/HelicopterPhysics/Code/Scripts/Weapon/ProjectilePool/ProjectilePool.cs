using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WheelApps {
    public class ProjectilePool : MonoBehaviour {
        #region Variables
        [Header("Pool Properties")]
        [SerializeField] protected float utilizeDistance = 100f;
        [SerializeField] protected int size = 10;

        [SerializeField] protected bool expandable = true;
        [Tooltip("If true the Utilize coroutine will be executed in the end of the \"GetPooledObject\" method.")]
        [SerializeField] protected bool utilizeInGet = true;

        
        [Header("Object properties")]
        [SerializeField] protected GameObject parentGO;
        [SerializeField] protected BaseProjectile pooledGO;
        
        protected Transform helicopter;
        protected List<BaseProjectile> pool = new List<BaseProjectile>();
        #endregion



        #region Builtin Methods
        private void Start() {
            helicopter = transform.root;
            
            FillPool(size, pooledGO, parentGO);
        }
        #endregion

        

        #region Custom Methods
        protected virtual BaseProjectile InstantiateObject(BaseProjectile prefab, GameObject parent, bool isActive = false) {
            var projectile = Instantiate(prefab == null ? new GameObject().AddComponent<BaseProjectile>() : prefab, parent.transform.position, parent.transform.rotation);
            var transform = parentGO.transform;
            projectile.transform.SetParent(transform);
            projectile.transform.SetPositionAndRotation(transform.position, transform.rotation);
            projectile.gameObject.SetActive(isActive);
            return projectile;
        }
        
                
        protected virtual void FillPool(int objectsAmount, BaseProjectile pooledGO = null, GameObject parentGO = null) {
            if (parentGO == null) parentGO = new GameObject(gameObject.name + "_projectiles");
            if (pooledGO == null)
                Instantiate(new GameObject().AddComponent<BaseProjectile>(),
                    parentGO.transform.position,
                    this.parentGO.transform.rotation);
            this.pooledGO = pooledGO;
            this.parentGO = parentGO;
            
            pool.Clear();
            for (var i = 0; i < objectsAmount; i++) {
                var projectile = InstantiateObject(pooledGO, parentGO); 
                pool.Add(projectile);
            }
        }
        
        
        public virtual BaseProjectile GetPooledObject() {
            foreach (var projectile in pool) {
                if (!projectile.gameObject.activeInHierarchy) {
                    projectile.gameObject.SetActive(true);
                    if (utilizeInGet) StartCoroutine(Utilize(projectile));
                    return projectile;
                }
            }

            if (!expandable) return null;
            var p = InstantiateObject(pooledGO, parentGO, true);
            pool.Add(p);
            if (utilizeInGet) StartCoroutine(Utilize(p));
            return p;
        }
        
        
        public virtual IEnumerator Utilize(BaseProjectile projectile) {
            yield return new WaitUntil(() => Vector3.Distance(helicopter.position, projectile.transform.position) > utilizeDistance);
            projectile.gameObject.SetActive(false);
            var t = projectile.transform;
            var pt = pooledGO.transform;
            t.localPosition = pt.position;
            t.localRotation = pt.rotation;
        }
        #endregion
    }
}
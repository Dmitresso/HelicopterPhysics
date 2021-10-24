using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


namespace WheelApps {
    public class ObjectPool : MonoBehaviour {
        #region Variables
        [Header("Pool Properties")]
        [SerializeField] protected int size = 10;

        [SerializeField] protected bool expandable = true;
        [Tooltip("If true the Utilize coroutine will be executed in the end of the \"GetPooledObject\" method.")]
        [SerializeField] protected bool utilizeInInstantiate = true;

        
        [Header("Object properties")]
        [SerializeField] public GameObject parentGO;
        [SerializeField] public GameObject pooledGO;

        protected List<GameObject> pool = new List<GameObject>();
        #endregion

        

        #region Builtin Methods
        private void Start() {
            FillPool(size, pooledGO, parentGO);
        }
        #endregion
        
        

        #region Custom Methods
        protected GameObject InstantiateObject(GameObject prefab, GameObject parent, bool isActive = false) {
            var gameObject = Instantiate(prefab == null ? new GameObject() : prefab, parent.transform.position, parent.transform.rotation);
            var transform = parentGO.transform;
            gameObject.transform.SetParent(transform);
            gameObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
            gameObject.SetActive(isActive);
            return gameObject;
        }

        
        protected virtual void FillPool(int objectsAmount, GameObject pooledGO = null, GameObject parentGO = null) {
            if (pooledGO == null) pooledGO = new GameObject();
            if (parentGO == null) parentGO = new GameObject(gameObject.name + "_projectiles");

            this.pooledGO = pooledGO;
            this.parentGO = parentGO;
            
            for (var i = 0; i < objectsAmount; i++) {
                var go = InstantiateObject(pooledGO, parentGO); 
                pool.Add(go);
            }
        }
        

        public GameObject GetPooledObject(bool utilizeInGet = false) {
            foreach (var gameObject in pool) {
                if (!gameObject.activeInHierarchy) {
                    gameObject.SetActive(true);
                    if (utilizeInGet) StartCoroutine(Utilize(gameObject));
                    return gameObject;
                }
            }

            if (!expandable) return null;
            var go = InstantiateObject(pooledGO, parentGO, true);
            pool.Add(go);
            if (utilizeInGet) StartCoroutine(Utilize(go));
            return go;
        }
        
        
        public virtual IEnumerator Utilize(GameObject pooledGO) {
            yield return new WaitForSeconds(1);
            pooledGO.transform.SetPositionAndRotation(parentGO.transform.position, parentGO.transform.rotation);
            pooledGO.gameObject.SetActive(false);
        }
        #endregion
    }
}
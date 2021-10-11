using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WheelApps {
    public class ObjectPool : MonoBehaviour {
        #region Variables
        [Header("Pool Properties")]
        public int size = 10;

        public bool expandable = true;
        [Tooltip("If true the Utilize coroutine will be executed in the end of the Instantiate method.")]
        public bool utilizeInInstantiate = true;
        public bool IsPooledObjectDefaultStateActive;

        
        [Header("Object properties")]
        public GameObject parentGO;
        public GameObject pooledGO;

        private List<GameObject> pool = new List<GameObject>();
        #endregion

        

        #region Builtin Methods
        private void Start() {
            FillPool(size, pooledGO, parentGO);
        }
        #endregion
        
        

        #region Custom Methods
        private GameObject InstantiateObject(GameObject prefab, GameObject parent, bool objectIsActive = false) {
            var gameObject = Instantiate(prefab == null ? new GameObject() : prefab, parent.transform.position, parent.transform.rotation);
            gameObject.transform.SetParent(parentGO.transform);
            gameObject.SetActive(objectIsActive);
            return gameObject;
        }

        
        public virtual void FillPool(int objectsAmount, GameObject pooledGO = null, GameObject parentGO = null) {
            if (pooledGO == null) pooledGO = new GameObject();
            if (parentGO == null) parentGO = new GameObject(gameObject.name + "_projectiles");

            this.pooledGO = pooledGO;
            this.parentGO = parentGO;
            
            for (var i = 0; i < objectsAmount; i++) {
                var go = InstantiateObject(pooledGO, parentGO, IsPooledObjectDefaultStateActive); 
                pool.Add(go);
            }
        }
        

        public GameObject GetPooledObject(bool searchingObjectStateIsActive = true, bool utilizeInInstantiate = true) {
            foreach (var gameObject in pool) {
                if (gameObject.activeInHierarchy == searchingObjectStateIsActive) {
                    if (utilizeInInstantiate) StartCoroutine(nameof(Utilize));
                    return gameObject;
                }
            }

            if (!expandable) return null;
            var go = InstantiateObject(pooledGO, parentGO, searchingObjectStateIsActive);
            pool.Add(go);
            if (utilizeInInstantiate) StartCoroutine(nameof(Utilize));
            return go;
        }
        
        
        public virtual IEnumerator Utilize() {
            yield return null;
        }
        #endregion
    }
}
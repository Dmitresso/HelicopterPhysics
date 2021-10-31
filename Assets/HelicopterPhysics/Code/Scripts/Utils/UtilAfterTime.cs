using System.Collections;
using UnityEngine;


namespace WheelApps {
    public class UtilAfterTime : MonoBehaviour {
        #region Variables
        public GameObject gameObject;
        public int removeAfterSec = 3;
        #endregion



        #region Builtin Methods
        private void OnEnable() {
            StartCoroutine(RemoveAfterSeconds(removeAfterSec, gameObject));
        }
        #endregion


        
        #region Custom Methods
        private IEnumerator RemoveAfterSeconds(int seconds, GameObject obj) {
            yield return new WaitForSeconds(seconds);
            obj.SetActive(false);
        }
        #endregion
    }
}
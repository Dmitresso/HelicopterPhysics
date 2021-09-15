using System.Collections.Generic;
using UnityEngine;

namespace WheelApps {
    public class RotorBlur : MonoBehaviour, IHelicopterRotor {
        #region Variables
        [Header("Rotor Blur Properties")]
        public float maxDps = 1000f;
        public List<GameObject> blades = new List<GameObject>();
        public GameObject blurGeo;
        public List<Texture2D> blurTextures = new List<Texture2D>(); 
        #endregion
        
        
        
        #region Interface Methods
        public void UpdateRotor(float dps, InputController input) {
            var normalizedDPS = Mathf.InverseLerp(0f, maxDps, dps);
            var blurTexId = Mathf.FloorToInt(normalizedDPS * blurTextures.Count - 1);
            blurTexId = Mathf.Clamp(blurTexId, 0, blurTextures.Count - 1);
            Debug.Log(blurTexId);
        }
        #endregion

    }
}
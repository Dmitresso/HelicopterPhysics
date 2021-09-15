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
        public Material blurMat;
        
        private static readonly int MainTex = Shader.PropertyToID("_MainTex");
        #endregion
        
        
        
        #region Interface Methods
        public void UpdateRotor(float dps, InputController input) {
            var normalizedDPS = Mathf.InverseLerp(0f, maxDps, dps);
            var blurTexId = Mathf.FloorToInt(normalizedDPS * blurTextures.Count - 1);
            blurTexId = Mathf.Clamp(blurTexId, 0, blurTextures.Count - 1);

            if (blurTextures.Count <= 0) return;
            if (blurMat) {
                blurMat.SetTexture(MainTex, blurTextures[blurTexId]);
            }

            HandleGeoBladeViz(blurTexId > 2);
        }


        private void HandleGeoBladeViz(bool viz) {
            foreach (var blade in blades) blade.SetActive(viz);
        }
        #endregion

    }
}
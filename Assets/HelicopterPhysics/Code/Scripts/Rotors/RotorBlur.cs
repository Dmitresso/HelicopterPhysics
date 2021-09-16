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
            //Debug.Log("Blurring Main Rotor");
            var normalizedDPS = Mathf.InverseLerp(0f, maxDps, dps);
            var blurTexID = Mathf.FloorToInt(normalizedDPS * blurTextures.Count - 1);
            blurTexID = Mathf.Clamp(blurTexID, 0, blurTextures.Count - 1);

            if (blurMat && blurTextures.Count > 0) 
                blurMat.SetTexture(MainTex, blurTextures[blurTexID]);
            

            if (blurTexID > 2 && blades.Count > 0) HandleGeoBladeViz(false);
            else HandleGeoBladeViz(true);

            HandleBlurGeo(blurTexID > 1);
        }
        

        private void HandleGeoBladeViz(bool viz) {
            foreach (var blade in blades) if (blade.activeSelf != viz) blade.SetActive(viz);
        }
        
        
        private void HandleBlurGeo(bool viz) {
            if (blurGeo && blurGeo.activeSelf != viz) blurGeo.SetActive(viz);
        }
        #endregion
    }
}
using UnityEngine;

namespace WheelApps {
    public class HelicopterEngine : MonoBehaviour {
        #region Variables
        public float maxHP = 140f;
        public float maxRPM = 2700f;
        public float powerDelay = 2f;

        private float currentHP;
        private float currentRPM;
        #endregion



        #region Properties
        public float CurrentHP => currentHP;
        public float CurrentRPM => currentRPM;
        #endregion
        
        

        #region Builtin Methods
        #endregion



        #region Custom Methods
        public void UpdateEngine(float throttle) {
            
        }
        #endregion
    }
}
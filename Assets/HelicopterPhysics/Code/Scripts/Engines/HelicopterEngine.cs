using UnityEngine;


namespace WheelApps {
    public class HelicopterEngine : MonoBehaviour {
        #region Variables
        public float maxHP = 140f;
        public float maxRPM = 2700f;
        public float powerDelay = 2f;
        public AnimationCurve powerCurve = new AnimationCurve(powerCurveKeyframes);

        private static Keyframe[] powerCurveKeyframes = {new Keyframe(0f, 0f), new Keyframe(1f, 1f)};
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

            var targetHP = powerCurve.Evaluate(throttle) * maxHP;
            currentHP = Mathf.Lerp(currentHP, targetHP, powerDelay * Time.deltaTime);
            
            var targetRPM = throttle * maxRPM;
            currentRPM = Mathf.Lerp(currentRPM, targetRPM, powerDelay * Time.deltaTime);
        }
        #endregion
    }
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace WheelApps {
    public class RotorController : MonoBehaviour {
        #region Variables
        public bool isArcade;
        public float maxDps = 3000f;
        public List<IHelicopterRotor> rotors;
        #endregion



        #region Builtin Methods
        private void Start() {
            rotors = GetComponentsInChildren<IHelicopterRotor>().ToList();
        }
        #endregion



        #region Custom Methods
        public void UpdateRotors(InputController input, float currentRPM) {
            // var dps = currentRPM * 360f / 60f * Time.deltaTime;
            var dps = currentRPM * 60f * Time.deltaTime;
            dps = Mathf.Clamp(dps, 0f, maxDps);

            if (isArcade) dps = 4000f;

            foreach (var rotor in rotors) rotor.UpdateRotor(dps, input);
        }
        #endregion
    }
}
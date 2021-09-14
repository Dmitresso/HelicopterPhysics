using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace WheelApps {
    public class RotorController : MonoBehaviour {
        #region Variables
        public List<IHelicopterRotor> rotors;
        #endregion



        #region Builtin Methods
        private void Start() {
            rotors = GetComponentsInChildren<IHelicopterRotor>().ToList();
            Debug.Log(rotors.Count);
        }
        #endregion



        #region Custom Methods
        public void UpdateRotors(InputController input, float currentRPM) {
            if (rotors.Count <= 0) return;
            foreach (var rotor in rotors) rotor.UpdateRotor();
        }
        #endregion
    }
}
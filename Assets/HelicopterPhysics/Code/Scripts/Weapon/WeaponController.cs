using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace WheelApps {
    public class WeaponController : MonoBehaviour {
        #region Variables
        [Header("Weapon Controller Properties")]
        public bool fireAllowed = true;

        private List<IWeapon> weapons = new List<IWeapon>();
        #endregion



        #region Builtin Methods
        private void Start() {
            weapons = GetComponentsInChildren<IWeapon>().ToList();
        }
        #endregion



        #region Custom Methods
        public void UpdateWeapons(InputController input) {
            if (!input.FireButton || !fireAllowed) return;
            if (weapons.Count <= 0) return;
            foreach (var weapon in weapons) weapon.FireWeapon();
        }
        #endregion
    }
}
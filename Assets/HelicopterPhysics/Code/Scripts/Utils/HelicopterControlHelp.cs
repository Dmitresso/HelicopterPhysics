using UnityEngine;


namespace WheelApps {
    public class HelicopterControlHelp : MonoBehaviour {
        #region Variables
        public CanvasGroup r22cg, hcg;
        #endregion



        #region Custom Methods
        public void SwitchVisibility(CanvasGroup cg) {
            var a = cg.alpha;
            cg.alpha = a switch {
                0 => 1,
                1 => 0,
                _ => a
            };
        }
        #endregion
    }
}
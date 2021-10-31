using UnityEngine;
using UnityEngine.UI;



namespace WheelApps {
    [RequireComponent(typeof(CanvasGroup))]
    public class HelicopterChoose : MonoBehaviour {
        #region Variables

        public Button r22Button, hueyButton;
        public GameObject r22h, r22cm, hh, hcm;
        public float fadeTime = 2f;

        private CanvasGroup canvasGroup;
        private bool fade;

        #endregion



        #region Builtin Methods

        private void Start() {
            canvasGroup = GetComponent<CanvasGroup>();
            r22Button.onClick.AddListener(delegate { HelicopterChooseButtonListener(0); });
            hueyButton.onClick.AddListener(delegate { HelicopterChooseButtonListener(1); });
        }


        private void Update() {
            if (!fade) return;
            fadeTime -= Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, fadeTime);
            if (fadeTime > 0) return;
            fade = false;
            gameObject.SetActive(false);
        }

        #endregion



        #region Custom Methods
        private void HelicopterChooseButtonListener(int index) {
            switch (index) {
                case 0:
                    foreach (var go in new[] { hcm, hh }) go.SetActive(false);
                    break;
                case 1:
                    foreach (var go in new[] { r22cm, r22h }) go.SetActive(false);
                    break;
            }
            fade = true;
        }

        #endregion
    }
}
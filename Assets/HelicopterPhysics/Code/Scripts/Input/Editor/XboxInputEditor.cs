using UnityEditor;


namespace WheelApps {
    [CustomEditor(typeof(XboxInput))]
    public class XboxInputEditor : Editor {
        #region Variables
        private XboxInput targetInput;
        #endregion



        #region Builtin methods
        private void OnEnable() {
            targetInput = (XboxInput) target;
        }


        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            DrawDebugUI();
            Repaint();
        }
        #endregion



        #region Custom Methods
        private void DrawDebugUI() {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.Space();
            EditorGUI.indentLevel++;
            EditorGUILayout.LabelField("Throttle: " + targetInput.RawThrottle.ToString("0.00"), EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Collective: " + targetInput.Collective.ToString("0.00"), EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Cyclic: " + targetInput.Cyclic.ToString("0.00"), EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Pedal: " + targetInput.Pedal.ToString("0.00"), EditorStyles.boldLabel);
            EditorGUI.indentLevel--;
            EditorGUILayout.Space();
            EditorGUILayout.EndVertical();
        }
        #endregion
    }
}
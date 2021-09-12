using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace IndiePixel
{
    [CustomEditor(typeof(IP_Advanced_HeliCamera))]
    public class IP_AdvancedHeliCamera_Editor : Editor
    {
        #region Variables
        IP_Advanced_HeliCamera targetCamera;
        #endregion

        #region Methods
        private void OnEnable()
        {
            targetCamera = (IP_Advanced_HeliCamera)target;
        }

        private void OnSceneGUI()
        {
            float minDist = targetCamera.minDistance;
            float maxDist = targetCamera.maxDistance;

            if (targetCamera.rb)
            {
                Vector3 targetFwd = targetCamera.rb.transform.forward;
                targetFwd.y = 0f;
                targetFwd = targetFwd.normalized;

                Handles.color = Color.blue;
                Handles.DrawWireDisc(targetCamera.rb.position, Vector3.up, minDist);
                Handles.DrawWireDisc(targetCamera.rb.position, Vector3.up, maxDist);

                targetCamera.minDistance = Handles.ScaleSlider(targetCamera.minDistance, targetCamera.rb.position + (targetFwd * minDist), Vector3.forward, Quaternion.identity, 1f, 1f);
                targetCamera.maxDistance = Handles.ScaleSlider(targetCamera.maxDistance, targetCamera.rb.position + (targetFwd * maxDist), Vector3.forward, Quaternion.identity, 1f, 1f);
            }
        }
        #endregion
    }
}

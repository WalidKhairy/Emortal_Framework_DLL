using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Emortal.Core;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Emortal.Players
{
    [System.Serializable]
    public class EF_Base_Thruster : EF_Base_Component 
    {
        #region Variables
        public float m_ThrusterForce = 100f;
        #endregion


        #region Runtime Methods
        protected override void HandleUpdate()
        {
            base.HandleUpdate();

            if(EF_InputGlobal.Instance != null && rb)
            {
                HandleThrusters();
            }
        }

        protected virtual void HandleThrusters()
        {
            //Handle The Jump
            if(!player.IsGrounded && EF_InputGlobal.Instance.jumpHold)
            {
                rb.AddForce(Vector3.up * m_ThrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
            }

        }
        #endregion




        #if UNITY_EDITOR
        #region Editor Methods
        protected override void HandleEditor(string aLabel)
        {
            base.HandleEditor("Basic Thrusters");
            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(10);
            EditorGUILayout.BeginVertical();
            showEditor = EditorGUILayout.Foldout(showEditor, "Properties", true);
            if(showEditor)
            {
                m_ThrusterForce = EditorGUILayout.FloatField("Jump Force: ", m_ThrusterForce);
            }
            GUILayout.Space(10);
            EditorGUILayout.EndVertical();
            GUILayout.Space(10);
            EditorGUILayout.EndHorizontal();

        }
        #endregion
        #endif
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Emortal.Core;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Emortal.Players
{
    public class EF_Base_Jump : EF_Base_Component 
    {
        #region Variables
        public float m_JumpForce = 100f;
        public float m_DownForce = 500f;
        #endregion


        #region Runtime Methods
        protected override void HandleUpdate()
        {
            base.HandleUpdate();

            if(EF_InputGlobal.Instance != null && rb)
            {
                HandleJump();
            }
        }

        protected virtual void HandleJump()
        {
            //Handle The Jump
            if(player.IsGrounded && EF_InputGlobal.Instance.jumpPressed)
            {
                rb.AddForce(Vector3.up * m_JumpForce * Time.fixedDeltaTime, ForceMode.Impulse);
            }
            else
            {
                rb.AddForce(Vector3.down * m_DownForce * Time.fixedDeltaTime, ForceMode.Impulse);
            }
        }
        #endregion




        #if UNITY_EDITOR
        #region Editor Methods
        protected override void HandleEditor(string aLabel)
        {
            base.HandleEditor("Basic Jump");
            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(10);
            EditorGUILayout.BeginVertical();
            showEditor = EditorGUILayout.Foldout(showEditor, "Properties", true);
            if(showEditor)
            {
                m_JumpForce = EditorGUILayout.FloatField("Jump Force: ", m_JumpForce);
                m_DownForce = EditorGUILayout.FloatField("Down Force: ", m_DownForce);
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

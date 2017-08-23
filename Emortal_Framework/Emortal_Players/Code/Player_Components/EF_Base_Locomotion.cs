using System.Collections;
using System.Collections.Generic;
using Emortal.Core;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Emortal.Players
{
    [System.Serializable]
    public class EF_Base_Locomotion : EF_Base_Component 
    {
        #region Variables
        public float m_ForwardSpeed = 5f;
        public float m_SpeedSmoothing = 0.5f;
        public float m_RotationSpeed = 10f;
        public float m_RotationSmoothing = 0.5f;

        protected float finalFwdSpeedValue = 0f;
        protected float finalRightSpeedValue = 0f;
        protected float fwdRefSpeedValue;
        protected float rightRefSpeedValue;

        protected float finalRotSpeedValue = 0f;
        protected float refRotSpeedValue;
        protected Vector3 forward = Vector3.zero;
        protected Vector3 right = Vector3.zero;
        #endregion




        #region RunTime Methods
        protected override void HandleUpdate()
        {
            base.HandleUpdate();

            if(EF_InputGlobal.Instance != null && rb)
            {
                HandleMovement();
                HandleRotation();
            }
        }

        protected virtual void HandleMovement()
        {
            //Handle the ground movement and Inputs
            if(player.IsGrounded)
            {
                finalFwdSpeedValue = Mathf.SmoothDamp(finalFwdSpeedValue, EF_InputGlobal.Instance.verticalInput * m_ForwardSpeed, ref fwdRefSpeedValue, m_SpeedSmoothing);
                forward = player.transform.forward * finalFwdSpeedValue;
            }
            Vector3 moveDir = forward * Time.fixedDeltaTime;


            //Update the Rigidbody Position
            rb.MovePosition(rb.position + moveDir);

        }

        protected virtual void HandleRotation()
        {
            //Handle the Rotation
            finalRotSpeedValue = Mathf.SmoothDamp(finalRotSpeedValue, EF_InputGlobal.Instance.horizontalInput * m_RotationSpeed, ref refRotSpeedValue, m_RotationSmoothing);
            Quaternion turnRotation = Quaternion.Euler(0f, finalRotSpeedValue * Time.fixedDeltaTime, 0f);

            //Apply the rotation
            rb.MoveRotation(rb.rotation * turnRotation);
        }
        #endregion





        #if UNITY_EDITOR
        #region Editor Methods
        protected override void HandleEditor(string aLabel)
        {
            base.HandleEditor(aLabel);
            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(10);
            EditorGUILayout.BeginVertical();
            showEditor = EditorGUILayout.Foldout(showEditor, "Properties", true);
            if(showEditor)
            {
                m_ForwardSpeed = EditorGUILayout.FloatField("Forward Speed: ", m_ForwardSpeed);
                m_SpeedSmoothing = EditorGUILayout.FloatField("Speed Smoothing: ", m_SpeedSmoothing);
                EditorGUILayout.Space();

                m_RotationSpeed = EditorGUILayout.FloatField("Rotation Speed: ", m_RotationSpeed);
                m_RotationSmoothing = EditorGUILayout.FloatField("Rotation Smoothing: ", m_RotationSmoothing);
                EditorGUILayout.Space();
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

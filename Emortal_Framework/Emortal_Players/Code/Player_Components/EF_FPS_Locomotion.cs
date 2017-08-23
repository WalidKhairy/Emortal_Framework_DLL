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
    public class EF_FPS_Locomotion : EF_Base_Component 
    {
        #region Variables
        public float m_ForwardSpeed = 5f;
        public float m_SpeedSmoothing = 0.5f;
        public float m_RotationSpeed = 10f;
        public float m_RotationSmoothing = 0.5f;

        protected float finalFwdSpeedValue = 0f;
        protected float finalRightSpeedValue = 0f;

        protected float finalRotSpeedValue = 0f;
        protected Vector3 forward = Vector3.zero;
        protected Vector3 right = Vector3.zero;
        protected Vector3 finalPosition;
        protected Vector3 finalRefPosition;
        #endregion


        #region Methods
        protected override void HandleUpdate()
        {
            base.HandleUpdate();

            if(EF_InputGlobal.Instance != null && rb)
            {
                HandleMovement();
                HandleRotation();
            }
        }

        protected void HandleMovement()
        {
            //Handle the ground movement and Inputs
            if(player.IsGrounded)
            {
                //Forward Speed
                finalFwdSpeedValue = EF_InputGlobal.Instance.verticalInput;
                forward = player.transform.forward * finalFwdSpeedValue;

                //Right Speed
                finalRightSpeedValue = EF_InputGlobal.Instance.horizontalInput;
                right = player.transform.right * finalRightSpeedValue;

            }
//            else
//            {
//                finalFwdSpeedValue = Mathf.Lerp(finalFwdSpeedValue, 0f, m_SpeedSmoothing);
//                finalRightSpeedValue = Mathf.Lerp(finalRightSpeedValue, 0f, m_SpeedSmoothing);;
//            }
            Vector3 moveDir = (forward + right).normalized * m_ForwardSpeed * Time.fixedDeltaTime;
            Debug.DrawRay(player.transform.position, moveDir, Color.red);


            //Update the Rigidbody Position
            finalPosition = Vector3.SmoothDamp(finalPosition, moveDir, ref finalRefPosition, m_SpeedSmoothing);
            rb.MovePosition(rb.position + finalPosition);
        }

        protected void HandleRotation()
        {
            //Handle the Rotation
            finalRotSpeedValue = Mathf.Lerp(finalRotSpeedValue, EF_InputGlobal.Instance.YAxis * m_RotationSpeed, m_RotationSmoothing);
            Quaternion turnRotation = Quaternion.Euler(0f, finalRotSpeedValue * Time.fixedDeltaTime, 0f);


            //Apply the rotation
            rb.MoveRotation(rb.rotation * turnRotation);
        }
        #endregion




        #if UNITY_EDITOR
        #region Editor Methods
        protected override void HandleEditor(string aLabel)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("FPS Locomotion", EditorStyles.boldLabel);
            GUILayout.FlexibleSpace();
            GUI.color = Color.red;
            if(GUILayout.Button("X"))
            {
                if(parentConfig != null)
                {
                    parentConfig.RemoveComponent(this);
                }
            }
            GUI.color = Color.white;
            EditorGUILayout.EndHorizontal();


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

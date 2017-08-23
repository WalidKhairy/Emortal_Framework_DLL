using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Emortal.Core
{
    [System.Serializable]
    public class EF_Base_Input : ScriptableObject
    {
        #region Variables
        public string inputName = "New Input";
        public InputType m_InputType = InputType.Keyboard;
        public string m_HorizontalInput = "Horizontal";
        public string m_VerticalInput = "Vertical";
        public string m_XAxis = "Mouse X";
        public string m_YAxis = "Mouse Y";

        public EF_Input_Scheme parentScheme;
        #endregion



        #region Methods
        public void UpdateInput()
        {
            HandleInput();
        }

        protected virtual void HandleInput()
        {
            EF_InputGlobal.Instance.horizontalInput = Input.GetAxisRaw(m_HorizontalInput);
            EF_InputGlobal.Instance.verticalInput = Input.GetAxisRaw(m_VerticalInput);

        }
        #endregion




        #if UNITY_EDITOR
        #region Editor Code
        public void UpdateEditor()
        {
            EditorGUI.BeginChangeCheck();
            HandleEditor();
            if(EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(this);
                AssetDatabase.SaveAssets();
            }


        }

        protected virtual void HandleEditor()
        {
            //Title bar for Input
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(inputName, EditorStyles.boldLabel);
            GUILayout.FlexibleSpace();
            GUI.color = Color.red;
            if(GUILayout.Button("X", GUILayout.Height(15), GUILayout.ExpandWidth(true)))
            {
                if(parentScheme != null)
                {
                    parentScheme.RemoveInput(this);
                }
            }
            GUI.color = Color.white;
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            //Common Inputs used by all Input Types
            m_HorizontalInput = EditorGUILayout.TextField("Horizontal Input: ", m_HorizontalInput);
            m_VerticalInput = EditorGUILayout.TextField("Vertical Input: ", m_VerticalInput);

            m_XAxis = EditorGUILayout.TextField("XAxis Input: ", m_XAxis);
            m_YAxis = EditorGUILayout.TextField("YAxis Input: ", m_YAxis);
        }
        #endregion
        #endif
    }
}

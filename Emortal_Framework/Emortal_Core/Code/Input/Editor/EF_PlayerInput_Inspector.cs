using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Emortal.Core
{
    [CustomEditor(typeof(EF_PlayerInput))]
    public class EF_PlayerInput_Inspector : Editor 
    {
        #region Variables
        EF_PlayerInput m_Target;
        #endregion

        #region Methods
        void OnEnable()
        {
            m_Target = (EF_PlayerInput)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.Space();

            //Lets make sure we have an Input Scheme first.  If not the User can create one 
            //by hitting the create button
            if(!m_Target.m_InputScheme)
            {
                EditorGUILayout.Space();
                if(GUILayout.Button("Add Input Scheme", GUILayout.Height(35), GUILayout.ExpandWidth(true)))
                {
                    m_Target.m_InputScheme = EF_Input_Editor_Utils.CreateInputScheme();
                }

                return;
            }


            //We do have a Scheme so lets draw the inputs and let the user create new Inputs
            EF_Input_Scheme inputScheme = m_Target.m_InputScheme;
            if(inputScheme.m_Inputs.Count > 0)
            {
                foreach(var input in inputScheme.m_Inputs)
                {
                    //Draw each Input Editor UI
                    EditorGUILayout.BeginHorizontal(GUI.skin.box);
                    GUILayout.Space(5);
                    EditorGUILayout.BeginVertical();
                    GUILayout.Space(5);
                    input.UpdateEditor();
                    GUILayout.Space(5);
                    EditorGUILayout.EndVertical();
                    GUILayout.Space(5);
                    EditorGUILayout.EndHorizontal();
                    GUILayout.Space(10);
                }
            }

            //Allow the user to create new Inputs
            EditorGUILayout.Space();
            if(GUILayout.Button("Add Input Type", GUILayout.Height(35), GUILayout.ExpandWidth(true)))
            {
                EF_Input_Editor_Utils.CreateNewInput(inputScheme);
            }
        }
        #endregion


        #region Utility Methods
        #endregion
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Emortal.Core
{
    public class EF_Grouping_Window : EF_Base_Window 
    {
        #region Variables
        static EF_Grouping_Window m_Win;
        private string m_GroupName = "Parent";
        #endregion


        #region Main Methods
        public static void InitWindow()
        {
            m_Win = GetWindow<EF_Grouping_Window>(true, "Object Grouping", true);


            m_Win.Show();
        }

        void OnEnable()
        {
            Selection.selectionChanged += GetSelected;
        }

        void OnDestroy()
        {
            Selection.selectionChanged -= GetSelected;
        }
           

        void OnGUI()
        {
            EditorGUILayout.LabelField("Objects Selected: " + m_SelectedObjects.Length);
            m_GroupName = EditorGUILayout.TextField("Group Name: ", m_GroupName);

            if(GUILayout.Button("Group Selected", GUILayout.Height(60)))
            {
                GroupSelected();
            }

            if(GUILayout.Button("UnGroup Selection", GUILayout.Height(60)))
            {
                UnGroupSelection();
            }

            if(m_Win)
            {
                m_Win.Repaint();
            }
        }
        #endregion

        #region Custom Methods
        void GroupSelected()
        {
            Transform parentGO = new GameObject(m_GroupName).transform;
            for(int i = 0; i < m_SelectedObjects.Length; i++)
            {
                Transform curTrans = m_SelectedObjects[i].transform;
                curTrans.SetParent(parentGO);
            }
        }

        void UnGroupSelection()
        {
            for(int i = 0; i < m_SelectedObjects.Length; i++)
            {
                Transform curTrans = m_SelectedObjects[i].transform;
                curTrans.SetParent(null);
            }
        }
        #endregion
    }
}

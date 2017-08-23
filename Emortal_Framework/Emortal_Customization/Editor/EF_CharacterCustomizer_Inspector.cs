using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Emortal.Core;

namespace Emortal.Customization
{
    [CustomEditor(typeof(EF_CharacterCustomizer))]
    public class EF_CharacterCustomizer_Inspector : Editor 
    {
        #region Variables
        EF_CharacterCustomizer targetManager;

        private GUISkin emortalSkin;
        #endregion


        #region Main Methods
    	// Use this for initialization
    	void OnEnable () 
        {
            emortalSkin = EF_Editor_Utils.GetInspectorEditorUI();
            targetManager = (EF_CharacterCustomizer)target;
    	}
            
    	
        public override void OnInspectorGUI()
        {
            EditorGUILayout.BeginVertical(emortalSkin.GetStyle("bgDark"));

            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            GUILayout.Space(12);
            EditorGUILayout.LabelField("Character Customizer", emortalSkin.GetStyle("h1"));
            GUILayout.EndVertical();

            GUILayout.FlexibleSpace();

            GUILayout.Box(EF_Editor_Utils.GetEmortalLogo(), emortalSkin.GetStyle("emptybox"));
            GUILayout.EndHorizontal();


            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(emortalSkin.GetStyle("bgDark002"));
            GUILayout.Space(10);
//            base.OnInspectorGUI();

            //Main Properites
            EditorGUILayout.LabelField("Configuration", emortalSkin.label);
            targetManager.m_BodyGrpName = EditorGUILayout.TextField("Body Group Name: ", targetManager.m_BodyGrpName, emortalSkin.textField);
            targetManager.m_HeadGrpName = EditorGUILayout.TextField("Head Group Name: ", targetManager.m_HeadGrpName, emortalSkin.textField);
            targetManager.m_CategorySuffix = EditorGUILayout.TextField("Category Suffix: ", targetManager.m_CategorySuffix, emortalSkin.textField);
            targetManager.m_ItemSuffix = EditorGUILayout.TextField("Item Suffix: ", targetManager.m_ItemSuffix, emortalSkin.textField);


            GUILayout.Space(20);


            EditorGUILayout.LabelField("Categories", emortalSkin.label);
            if(targetManager.m_Categories.Count > 0)
            {
                foreach(var category in targetManager.m_Categories)
                {
                    if(category != null)
                    {
                        if(GUILayout.Button(category.gameObject.name, emortalSkin.button, GUILayout.Height(48)))
                        {
                            GUILayout.BeginHorizontal();
                            GUILayout.EndHorizontal();
                        }
                    }
                }
            }
            else
            {
                EditorGUILayout.LabelField("Character has not been setup...");
            }


            GUILayout.Space(40);


            if(GUILayout.Button("Setup Character", emortalSkin.button, GUILayout.ExpandWidth(true), GUILayout.Height(35f)))
            {
                targetManager.InitializeCustomization();
            }

            if(GUILayout.Button("Clean Data", emortalSkin.button, GUILayout.ExpandWidth(true), GUILayout.Height(35f)))
            {
                targetManager.CleanData();
            }

            GUILayout.Space(10);
            EditorGUILayout.EndVertical();


            EditorGUILayout.BeginVertical(emortalSkin.GetStyle("bgDark"));
//            GUILayout.Space(10);
            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));

            GUILayout.BeginVertical();
            GUILayout.Space(8);
            if(GUILayout.Button("www.emortalsports.com", emortalSkin.GetStyle("urlbutton")))
            {
                Application.OpenURL("http://www.emortalsports.com");
            }
            GUILayout.EndVertical();

            GUILayout.FlexibleSpace();

            GUILayout.Box(EF_Editor_Utils.GetEmortalLogo(), emortalSkin.GetStyle("emptybox"));

            GUILayout.EndHorizontal();
//            GUILayout.Space(10);
            EditorGUILayout.EndVertical();

            Repaint();
        }
        #endregion
    }
}

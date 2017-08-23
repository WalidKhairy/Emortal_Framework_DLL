using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Emortal.Core;

namespace Emortal.Customization
{
    [CustomEditor(typeof(EF_Customization_Panel))]
    public class EF_CustomizerPanel_Inspector : Editor 
    {
        #region Variables
        EF_Customization_Panel targetScript;
        GUISkin emortalSkin;
        #endregion

        #region Main Methods
        void OnEnable()
        {
            targetScript = (EF_Customization_Panel)target;
            emortalSkin = EF_Editor_Utils.GetInspectorEditorUI();
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.BeginVertical(emortalSkin.GetStyle("bgDark"));

            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            GUILayout.Space(12);
            EditorGUILayout.LabelField("Customizer Panel", emortalSkin.GetStyle("h1"));
            GUILayout.EndVertical();

            GUILayout.FlexibleSpace();

            GUILayout.Box(EF_Editor_Utils.GetEmortalLogo(), emortalSkin.GetStyle("emptybox"));
            GUILayout.EndHorizontal();


            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(emortalSkin.GetStyle("bgDark002"));
            GUILayout.Space(10);
            base.OnInspectorGUI();
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

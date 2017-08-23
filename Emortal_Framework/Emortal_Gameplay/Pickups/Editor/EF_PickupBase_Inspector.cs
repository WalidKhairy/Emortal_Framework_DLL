using System.Collections;
using System.Collections.Generic;
using Emortal.Gameplay;
using UnityEditor;
using UnityEngine;

namespace Emortal.Gameplay
{
    public class EF_PickupBase_Inspector : Editor 
    {
        #region Methods
        public override void OnInspectorGUI()
        {
            DrawHeader("Pickup Base");
            DrawBody();
            DrawFooter();
        }

        protected virtual void DrawHeader(string aTitle)
        {
            EditorGUILayout.BeginVertical(GUI.skin.box, GUILayout.ExpandWidth(true));

            EditorGUILayout.LabelField(aTitle);

            EditorGUILayout.EndVertical();
        }

        protected virtual void DrawBody()
        {
            EditorGUILayout.BeginVertical(GUI.skin.box, GUILayout.ExpandWidth(true));

            EditorGUILayout.Space();
            DrawDefaultInspector();
            EditorGUILayout.Space();

            EditorGUILayout.EndVertical();
        }

        protected virtual void DrawFooter()
        {
            EditorGUILayout.BeginVertical(GUI.skin.box, GUILayout.ExpandWidth(true));

            EditorGUILayout.LabelField("Emortal Framework - 2017");

            EditorGUILayout.EndVertical();
        }
        #endregion
    }
}

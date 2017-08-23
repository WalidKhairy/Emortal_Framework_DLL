using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Emortal.Core;

namespace Emortal.Gameplay
{
    [CustomEditor(typeof(EF_Base_Weapon))]
    public class EF_Weapon_Inspector : Editor
    {
        #region Variables
        protected EF_Base_Weapon targetBase;
        private GUISkin editorSkin;
        protected string title = "Base Weapon";
        #endregion

        #region Methods
        public virtual void OnEnable()
        {
            targetBase = (EF_Base_Weapon)target;
            editorSkin = EF_Editor_Utils.GetInspectorEditorUI();

            EditorApplication.update += Update;
        }

        public virtual void OnDisable()
        {
            EditorApplication.update -= Update;
        }

        void Update()
        {
            if(!editorSkin)
            {
                editorSkin = EF_Editor_Utils.GetInspectorEditorUI();
                return;
            }
        }

        public override void OnInspectorGUI()
        {
//            DrawDefaultInspector();
            EditorGUILayout.BeginVertical(editorSkin.GetStyle("bgDark"), GUILayout.ExpandWidth(true), GUILayout.Height(40));
            GUILayout.Space(10);
            EditorGUILayout.LabelField(title, editorSkin.GetStyle("h1"));
            GUILayout.Space(10);
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(editorSkin.GetStyle("bgMid"), GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            DrawDefaultInspector();
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(editorSkin.GetStyle("bgDark"), GUILayout.ExpandWidth(true), GUILayout.Height(30));
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("copyright@2017 |  www.emortalsports.com", editorSkin.GetStyle("blue_label"));
            GUILayout.FlexibleSpace();
            EditorGUILayout.LabelField("", editorSkin.GetStyle("emortal_logo"), GUILayout.Width(35f), GUILayout.Height(35f));

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();

            Repaint();
        }

        public virtual void OnSceneGUI()
        {
            Handles.BeginGUI();
            GUILayout.BeginArea(new Rect(25f, Screen.height - 250f, 250f, 200f), editorSkin.GetStyle("bgDark"));

            EditorGUILayout.LabelField("Weapon Properties:");
            EditorGUILayout.Space();
            targetBase.m_AmmoCount = EditorGUILayout.IntField("Ammo Count: ", targetBase.m_AmmoCount); 

            GUILayout.EndArea();
            Handles.EndGUI();

            Matrix4x4 oldMatrix = Handles.matrix;
            Handles.matrix = targetBase.transform.localToWorldMatrix;

            Vector3 fwd = targetBase.transform.forward;

            targetBase.m_MuzzlePosition = Handles.PositionHandle(targetBase.m_MuzzlePosition, Quaternion.LookRotation(targetBase.transform.InverseTransformDirection(fwd)));
            Handles.Label(targetBase.m_MuzzlePosition, "Muzzle Position");

            targetBase.m_GripPosition = Handles.PositionHandle(targetBase.m_GripPosition, Quaternion.LookRotation(targetBase.transform.InverseTransformDirection(fwd)));
            Handles.Label(targetBase.m_GripPosition, "Grip Position");

            Handles.Label(targetBase.transform.InverseTransformPoint(targetBase.transform.position), "Weapon Transform");

            Handles.matrix = oldMatrix;

            SceneView.RepaintAll();

        }
        #endregion
    }
}

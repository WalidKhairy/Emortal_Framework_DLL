using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Emortal.Gameplay
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(EF_Door_Base))]
    public class EF_Door_Editor : Editor 
    {
        #region Variables
        private EF_Door_Base targetDoor;
        #endregion

        #region Methods
        void OnEnable()
        {
            targetDoor = (EF_Door_Base)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }

        void OnSceneGUI()
        {
            Matrix4x4 oldMatrix = Handles.matrix;
            Handles.matrix = targetDoor.transform.localToWorldMatrix;

            Handles.color = Color.yellow;
            Vector3 dir = targetDoor.m_OpenPosition - targetDoor.transform.position;
            targetDoor.m_OpenPosition = Handles.FreeMoveHandle(targetDoor.m_OpenPosition, Quaternion.LookRotation(dir), 0.35f, Vector3.one, Handles.ConeHandleCap);

            Handles.color = Color.white;
            Handles.DrawLine(Vector3.zero, targetDoor.m_OpenPosition);


            Handles.matrix = oldMatrix;

        }
        #endregion
    }
}

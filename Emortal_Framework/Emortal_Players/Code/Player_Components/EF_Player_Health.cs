using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//#if UNITY_EDITOR
//using UnityEditor;
//#endif

namespace Emortal.Players
{
    [System.Serializable]
    public class EF_Player_Health : MonoBehaviour, IDamagable
    {
        #region Variables
        public float m_TotalHealth = 100f;

        public UnityEvent OnDeathEvent = new UnityEvent();

        protected float m_CurrentHealth;
        public float GetHealth
        {
            get{return m_CurrentHealth;}
        }
        #endregion




        #region Runtime Methods
        /// <summary>
        /// Applies the damage through a SendEvent Message.
        /// Also handles the death event when Health is at 0.
        /// </summary>
        /// <param name="damageAmount">Damage amount.</param>
        public void ApplyDamage(float damageAmount)
        {
            m_CurrentHealth -= damageAmount;
            m_CurrentHealth = Mathf.Clamp(m_CurrentHealth, 0f, m_TotalHealth);
            if(m_CurrentHealth == 0f)
            {
                if(OnDeathEvent != null)
                {
                    OnDeathEvent.Invoke();
                }
            }
        }

        public virtual void ResetHealth()
        {
            m_CurrentHealth = m_TotalHealth;
        }
        #endregion




//        #if UNITY_EDITOR
//        #region Editor Methods
//        protected override void HandleEditor(string aLabel)
//        {
//            base.HandleEditor("Basic Health");
//
//            EditorGUILayout.Space();
//
//            EditorGUILayout.BeginHorizontal();
//            GUILayout.Space(10);
//            EditorGUILayout.BeginVertical();
//
//            showEditor = EditorGUILayout.Foldout(showEditor, "Properties", true);
//            if(showEditor)
//            {
//                m_TotalHealth = EditorGUILayout.FloatField("Total Health: ", m_TotalHealth);
//
//                EditorGUILayout.Space();
//                SerializedObject myObj = new UnityEditor.SerializedObject(this);
//                SerializedProperty eventProp = myObj.FindProperty("OnDeathEvent");
//                EditorGUILayout.PropertyField(eventProp);
//                myObj.ApplyModifiedProperties();
//            }
//
//            GUILayout.Space(10);
//            EditorGUILayout.EndVertical();
//            GUILayout.Space(10);
//            EditorGUILayout.EndHorizontal();
//        }
//        #endregion
//        #endif
    }
}

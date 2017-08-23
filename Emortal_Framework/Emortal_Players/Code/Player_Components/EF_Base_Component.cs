using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Emortal.Players
{
    public enum ComponentType
    {
        Locomotion = 0,
        Health = 1,
        Weapon = 2,
    }

    [System.Serializable]
    public class EF_Base_Component : ScriptableObject 
    {
        #region Variables
        public ComponentType m_ComponentType;
        protected EF_Player player;
        protected Rigidbody rb;

        public EF_Player_Config parentConfig;
        public bool showEditor = false;
        #endregion

        #region Runtime Methods
        public virtual void InitComponent(){}

        public void UpdateComponent(UpdateConfigArgs args)
        {
            if(args != null)
            {
                if(args.aPlayer)
                {
                    player = args.aPlayer;
                    if(!rb)
                    {
                        rb = args.aPlayer.GetComponent<Rigidbody>();
                    }
                    HandleUpdate();
                }
            }
        }
        protected virtual void HandleUpdate(){}
        public virtual void ResetComponent(){}
        #endregion



        #if UNITY_EDITOR
        #region Editor Methods
        public void DrawEditor()
        {
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.BeginVertical(GUI.skin.box);
            HandleEditor("Base");
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();
        }

        protected virtual void HandleEditor(string aTitle)
        {
            
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(aTitle, EditorStyles.boldLabel);
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

        }
        #endregion
        #endif
    }
}

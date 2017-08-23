using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Emortal.Players
{
    [CustomEditor(typeof(EF_Player))]
    public class EF_Player_Inspector : Editor 
    {
        #region Variables
        EF_Player targetPlayer;
        #endregion

        #region Methods
        void OnEnable()
        {
            targetPlayer = (EF_Player)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            //Lets make sure we have a config file in place
            //if not prompt the user to create one.
            EditorGUILayout.Space();
            if(targetPlayer.m_PlayerConfig == null)
            {
                if(GUILayout.Button("Create Player Config", GUILayout.Height(35f), GUILayout.ExpandWidth(true)))
                {
                    targetPlayer.m_PlayerConfig = EF_PlayerEditor_Utils.CreatePlayerConfig();
                }

                return;
            }


            //We have a Config File so Lets render the Component Editors
            targetPlayer.m_PlayerConfig.DrawEditor();

            EditorGUILayout.Space();
            if(GUILayout.Button("Add Component", GUILayout.Height(35f), GUILayout.ExpandWidth(true)))
            {
                EF_PlayerEditor_Utils.AddPlayerComponent(targetPlayer.m_PlayerConfig);
            }
        }
        #endregion
    }
}

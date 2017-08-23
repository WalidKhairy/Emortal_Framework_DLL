using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Emortal.Players
{
    public class AddComponentArgs : EventArgs
    {
        public EF_Base_Component aComponent;
    }

    public class UpdateConfigArgs : EventArgs
    {
        public EF_Player aPlayer;
    }

    [Serializable]
    public class EF_Player_Config : ScriptableObject 
    {
        #region Variables
        public string m_ConfigName = "Payer_Config";
        public List<EF_Base_Component> m_Compnents = new List<EF_Base_Component>();

        public delegate void onResetConfig();
        public event onResetConfig OnResetConfig;

        public delegate void onUpdateConfig(UpdateConfigArgs args);
        public event onUpdateConfig OnUpdateConfig;
        #endregion

        #region Runtime Methods
        /// <summary>
        /// Inits the config.
        /// </summary>
        public void InitConfig( )
        {
            if(m_Compnents.Count > 0)
            {
                foreach(var component in m_Compnents)
                {
                    OnUpdateConfig += component.UpdateComponent;
                    OnResetConfig += component.ResetComponent;
                }
            }
        }

        /// <summary>
        /// Disables the config.
        /// </summary>
        public void DisableConfig()
        {
            if(m_Compnents.Count > 0)
            {
                foreach(var component in m_Compnents)
                {
                    OnUpdateConfig -= component.UpdateComponent;
                    OnResetConfig -= component.ResetComponent;
                }
            }
        }
        /// <summary>
        /// Updates the config and all of its components
        /// </summary>
        public void UpdateConfig(EF_Player aPlayer)
        {
            if(OnUpdateConfig != null && aPlayer)
            {
                UpdateConfigArgs args = new UpdateConfigArgs();
                args.aPlayer = aPlayer;
                OnUpdateConfig(args);
            }
        }

        /// <summary>
        /// Resets the config and all of its components
        /// </summary>
        public void ResetConfig()
        {
            if(OnResetConfig != null)
            {
                OnResetConfig();
            }
        }
        #endregion



        #if UNITY_EDITOR
        #region Editor Methods
        public void DrawEditor()
        {
            if(m_Compnents.Count > 0)
            {
                for(int i = 0; i < m_Compnents.Count; i++)
                {
                    if(m_Compnents[i] != null)
                    {
                        EditorGUI.BeginChangeCheck();
                        m_Compnents[i].DrawEditor();
                        if(EditorGUI.EndChangeCheck())
                        {
                            EditorUtility.SetDirty(this);
                        }
                    }
                }
            }
        }

        public void AddComponent(object sender, AddComponentArgs args)
        {
//            Debug.Log("Adding Component");
            if(args != null)
            {
                if(args.aComponent != null)
                {
                    m_Compnents.Add(args.aComponent);

                    args.aComponent.parentConfig = this;
                    AssetDatabase.AddObjectToAsset(args.aComponent, this);
                    AssetDatabase.SaveAssets();
                }
            }
        }

        public void RemoveComponent(EF_Base_Component aComponent)
        {
            if(aComponent && m_Compnents.Count > 0)
            {
                m_Compnents.Remove(aComponent);
                UnityEngine.Object.DestroyImmediate(aComponent, true);

                EditorUtility.SetDirty(this);
                AssetDatabase.SaveAssets();
            }
        }
        #endregion
        #endif
    }
}
    
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Emortal.Players
{
    public static class EF_PlayerEditor_Utils 
    {
        /// <summary>
        /// Creates a new player config and saves it to the Asset Database
        /// </summary>
        /// <returns>The player config.</returns>
        public static EF_Player_Config CreatePlayerConfig()
        {
            //Create the new Data Container
            EF_Player_Config playerConfig = ScriptableObject.CreateInstance<EF_Player_Config>();

            //Get the User defined path
            string dataPath = EditorUtility.SaveFilePanel("Create Input Scheme", "Assets", "New_Player_Config", "asset");
            if(dataPath.Length > 0)
            {
                //Create the Asset and Save the Database
                AssetDatabase.CreateAsset(playerConfig, dataPath.Substring(dataPath.IndexOf("Assets")));
                AssetDatabase.SaveAssets();

                //Return the player config
                return playerConfig;
            }
            else
            {
                //We were unsuccessful in creating the new player config
                return null;
            }
        }


        /// <summary>
        /// Adds the player component.
        /// </summary>
        /// <param name="playerConfig">Player config.</param>
        public static void AddPlayerComponent(EF_Player_Config playerConfig)
        {
            EF_PlayerComponent_Popup win = EF_PlayerComponent_Popup.InitPlayerComponentPopup();
            if(win != null)
            {
                win.OnAdd += playerConfig.AddComponent;
            }
        }
    }



}

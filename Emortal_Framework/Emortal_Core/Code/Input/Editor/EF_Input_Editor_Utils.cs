using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Emortal.Core
{
    public class EF_Input_Editor_Utils 
    {
        /// <summary>
        /// Creates a new input scheme.
        /// </summary>
        /// <returns>The input scheme.</returns>
        public static EF_Input_Scheme CreateInputScheme()
        {
            //Create the new Data Container
            EF_Input_Scheme inputScheme = ScriptableObject.CreateInstance<EF_Input_Scheme>();

            //Get the User defined path
            string dataPath = EditorUtility.SaveFilePanel("Create Input Scheme", "Assets", "New_Input_Scheme", "asset");
            if(dataPath.Length > 0)
            {
                //Create the Asset and Save the Database
                AssetDatabase.CreateAsset(inputScheme, dataPath.Substring(dataPath.IndexOf("Assets")));
                AssetDatabase.SaveAssets();

                //Return the input scheme
                return inputScheme;
            }
            else
            {
                //We were unsuccessful in creating the new input scheme
                return null;
            }
        }


        /// <summary>
        /// Creates a new input.
        /// </summary>
        /// <returns>The new input.</returns>
        public static void CreateNewInput(EF_Input_Scheme inputScheme)
        {
            EF_Input_Popup win = EF_Input_Popup.InitInputPopup();
            win.OnComplete += inputScheme.AddInput;
        }
    }
}

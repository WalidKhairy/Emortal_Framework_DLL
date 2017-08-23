using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Emortal.Core
{
    public class InputPopupArgs : EventArgs
    {
        public EF_Base_Input curInput;
    }

    public class EF_Input_Scheme : ScriptableObject 
    {
        //Constructor for this class to set up defaults
        public EF_Input_Scheme()
        {
            m_Inputs = new List<EF_Base_Input>();
        }

        #region Variables
        public List<EF_Base_Input> m_Inputs;
        #endregion

        #if UNITY_EDITOR
        #region Editor Methods
        public void AddInput(object sender, InputPopupArgs args)
        {
            if(args != null && args.curInput != null)
            {
                args.curInput.parentScheme = this;
                m_Inputs.Add(args.curInput);

                #if UNITY_EDITOR
                AssetDatabase.AddObjectToAsset(args.curInput, this);
                AssetDatabase.SaveAssets();
                #endif

            }
        }

        public void RemoveInput(EF_Base_Input anInput)
        {
            if(anInput)
            {
                m_Inputs.Remove(anInput);
                UnityEngine.Object.DestroyImmediate(anInput, true);

                EditorUtility.SetDirty(this);
                AssetDatabase.SaveAssets();
            }
        }
        #endregion
        #endif
    }
}

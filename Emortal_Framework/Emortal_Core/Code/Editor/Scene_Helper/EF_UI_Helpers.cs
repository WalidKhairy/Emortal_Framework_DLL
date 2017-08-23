using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Emortal.UI;

namespace Emortal.Core
{
    public enum ScreenTypes
    {
        Base,
        Timed
    }

    public static class EF_UI_Helpers 
    {
        public static void CreateUIGroup()
        {
            GameObject selectedGO = EF_Editor_Utils.GetSelectedObject();
            GameObject uiGrp = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Emortal_Framework/Emortal_UI/Prefabs/UI_GRP.prefab", typeof(GameObject));
            if(uiGrp)
            {
                GameObject curUIGrp = GameObject.Instantiate(uiGrp);
                curUIGrp.name = "UI_GRP";

                if(selectedGO)
                {
                    curUIGrp.transform.SetParent(selectedGO.transform);
                }
            }
            else
            {
                EF_Editor_Utils.DisplayDialogBox("Unable to Find the UI_GRP Prefab!");
            }
        }

        public static void CreateUIScreen(ScreenTypes aScreenType)
        {
            GameObject curSelected = EF_Editor_Utils.GetSelectedObject();

            GameObject curScreenGO = null;
            switch(aScreenType)
            {
                case ScreenTypes.Base:
                    curScreenGO = new GameObject("New Screen", typeof(EF_Base_Screen), typeof(RectTransform));
                    break;

                case ScreenTypes.Timed:
                    curScreenGO = new GameObject("New Screen", typeof(EF_Timed_Screen), typeof(RectTransform));
                    break;

                default:
                    break;
            }

            if(curSelected)
            {
                curScreenGO.transform.SetParent(curSelected.transform);
            }

            Selection.activeGameObject = curScreenGO;
        }

    }
}

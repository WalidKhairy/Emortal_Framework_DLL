using UnityEngine;
using UnityEditor;
using Emortal.Core;

namespace Emortal.Customization
{
    public class EF_Customization_Menus 
    {
        [MenuItem("Emortal/Customization/Set up Character")]
        public static void SetupCharacter()
        {
            //get the selected gameobject
            GameObject curGO = EF_Editor_Utils.GetSelectedObject("Please select a Character to Set up!");
            if(!curGO)
            {
                return;
            }

            //Add the Customizer script to the GameObject
            EF_CharacterCustomizer curCustomizer = curGO.AddComponent<EF_CharacterCustomizer>();
            curCustomizer.InitializeCustomization();

            Selection.activeGameObject = curGO;
        }
    }
}

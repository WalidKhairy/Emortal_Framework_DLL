using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Emortal.Core;

namespace Emortal.Gameplay
{
    public class EF_Trigger_Menus 
    {
        [MenuItem("Emortal/Gameplay/Triggers/Create Base Trigger")]
        public static void CreateBaseTrigger()
        {
            GameObject triggerGO = new GameObject("Base Trigger", typeof(EF_Trigger_Base));

            EF_Editor_Utils.DrawIcon(triggerGO, 4);

            Selection.activeGameObject = triggerGO;
        }
    }
}

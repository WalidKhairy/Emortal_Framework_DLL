using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Emortal.Gameplay
{
    public class EF_Gameplay_Menus : MonoBehaviour 
    {
        [MenuItem("Emortal/Gameplay/Sequence Designer")]
        public static void InitSequenceDesigner()
        {
            EF_SequenceDesigner_Window.InitSequenceDesigner();
        }
    }
}

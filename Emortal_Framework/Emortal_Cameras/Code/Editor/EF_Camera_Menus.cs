using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Emortal.Core;

namespace Emortal.Cameras
{
    public class EF_Camera_Menus 
    {
        #region Menus
        [MenuItem("Emortal/Cameras/Create FPS Camera")]
        public static void CreateFPSCamera()
        {
//            Debug.Log("Creating an FPS Camera");
            GameObject selectedGO = EF_Editor_Utils.GetSelectedObject("Please Select a Game Object to attach an FPS camera to!");
            if(!selectedGO)
            {
                return;
            }
                

            //We have a selected Object so lets create an FPS camera for it.
            GameObject camGO = new GameObject("FPS Camera", typeof(Camera), typeof(EF_FirstPerson_Camera));
            camGO.transform.position = new Vector3(0f, 1.5f, 0f);
            camGO.transform.SetParent(selectedGO.transform);
        }
        #endregion
    }
}

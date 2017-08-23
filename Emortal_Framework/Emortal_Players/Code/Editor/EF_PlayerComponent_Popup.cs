using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Emortal.Players
{
    public class EF_PlayerComponent_Popup : EditorWindow 
    {
        #region Variables
        public delegate void onAdd(object sender, AddComponentArgs args);
        public event onAdd OnAdd;
        #endregion


        #region Methods
        public static EF_PlayerComponent_Popup InitPlayerComponentPopup()
        {
            var win = EditorWindow.GetWindow<EF_PlayerComponent_Popup>();
            win.ShowUtility();
            return win;
        }

        void OnGUI()
        {
            EditorGUILayout.LabelField("Player Components");

            if(GUILayout.Button("Base Locomotion"))
            {
                var curComponent = new EF_Base_Locomotion();
                if(OnAdd != null)
                {
                    AddComponentArgs args = new AddComponentArgs();
                    args.aComponent = curComponent;
                    OnAdd(this, args);
                }
                this.Close();
            }

            if(GUILayout.Button("FPS Locomotion"))
            {
                var curComponent = new EF_FPS_Locomotion();
                if(OnAdd != null)
                {
                    AddComponentArgs args = new AddComponentArgs();
                    args.aComponent = curComponent;
                    OnAdd(this, args);
                }
                this.Close();
            }

            if(GUILayout.Button("Base Jump"))
            {
                var curComponent = new EF_Base_Jump();
                if(OnAdd != null)
                {
                    AddComponentArgs args = new AddComponentArgs();
                    args.aComponent = curComponent;
                    OnAdd(this, args);
                }
                this.Close();
            }

            if(GUILayout.Button("Base Thrusters"))
            {
                var curComponent = new EF_Base_Thruster();
                if(OnAdd != null)
                {
                    AddComponentArgs args = new AddComponentArgs();
                    args.aComponent = curComponent;
                    OnAdd(this, args);
                }
                this.Close();
            }


            if(GUILayout.Button("Close", GUILayout.Height(25), GUILayout.ExpandWidth(true)))
            {
                this.Close();
            }
        }
        #endregion
    }
}

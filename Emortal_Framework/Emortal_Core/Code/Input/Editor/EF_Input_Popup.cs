using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Emortal.Core
{
    public class EF_Input_Popup : EditorWindow 
    {
        #region Variables
        public delegate void onComplete(object sender, InputPopupArgs args);
        public event onComplete OnComplete;

        private InputType wantedType = InputType.Keyboard;
        private string wantedName = "New Input";
        #endregion

        #region Methods
        public static EF_Input_Popup InitInputPopup()
        {
            EF_Input_Popup win = ScriptableObject.CreateInstance<EF_Input_Popup>();
            win.position = new Rect(Screen.width/2f, Screen.height/2f, 250f, 150f);
            win.ShowPopup();
            return win;
        }

        void OnGUI()
        {
            GUILayout.BeginVertical();
            wantedName = EditorGUILayout.TextField("Input Name: ", wantedName);
            wantedType = (InputType)EditorGUILayout.EnumPopup("Input Type: ", wantedType);


            GUILayout.BeginHorizontal("", GUILayout.ExpandWidth(true));
            if(GUILayout.Button("Create"))
            {
                var newInput = new EF_Base_Input();
                switch(wantedType)
                {
                    case InputType.Keyboard:
                        newInput = new EF_Keyboard_Input() as EF_Keyboard_Input;
                        newInput.inputName = wantedName;
                        newInput.m_InputType = InputType.Keyboard;
                        break;

                    case InputType.Xbox:
                        newInput = new EF_Joystick_Input() as EF_Joystick_Input;
                        newInput.inputName = wantedName;
                        newInput.m_InputType = InputType.Xbox;
                        newInput.m_XAxis = "4ThAxis";
                        newInput.m_YAxis = "5ThAxis";
                        break;

                    case InputType.PS4:
                        newInput = new EF_Joystick_Input() as EF_Joystick_Input;
                        newInput.inputName = wantedName;
                        newInput.m_InputType = InputType.PS4;
                        newInput.m_XAxis = "3rdAxis";
                        newInput.m_YAxis = "6ThAxis";
                        break;

                    case InputType.Vive:
                        newInput = new EF_Joystick_Input() as EF_Joystick_Input;
                        newInput.inputName = wantedName;
                        newInput.m_InputType = InputType.Vive;
                        break;

                    default:
                        break;
                }

                if(OnComplete != null)
                {
                    InputPopupArgs args = new InputPopupArgs();
                    args.curInput = newInput;
                    OnComplete(this, args);
                }
                this.Close();
            }

            if(GUILayout.Button("Close"))
            {
                this.Close();
            }
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        }
        #endregion
    }
}

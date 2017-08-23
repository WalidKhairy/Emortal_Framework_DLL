using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Core
{
    public class EF_PlayerInput : MonoBehaviour 
    {
        #region Variables
        public EF_Input_Scheme m_InputScheme;
        public bool m_AllowInputs = true;

        private bool isXbox = false;
        #endregion



        #region Methods
        void Update()
        {
            if(m_InputScheme && m_InputScheme.m_Inputs.Count > 0 && m_AllowInputs)
            {
                SetInputs();
            }
        }

        /// <summary>
        /// Set Inputs: Handles Dynamically selecting the Input Type and
        /// updating chosen Inputs.
        /// </summary>
        protected void SetInputs()
        {
            if(Input.GetJoystickNames().Length > 0)
            {
                string joystickName = Input.GetJoystickNames()[0];
                isXbox = joystickName.ToLower().IndexOf("xbox") >= 0;

                //we are using a Joystick
                if(isXbox)
                {
                    //Update the Xbox Controls
                    HandleInput(InputType.Xbox);
                }
                else
                {
                    //Update the Generic Joystick
                    HandleInput(InputType.PS4);
                }
            }

            HandleInput(InputType.Keyboard);
        }

        /// <summary>
        /// Handles the input selection and updates at RunTime
        /// </summary>
        /// <param name="inputType">Input type.</param>
        void HandleInput(InputType inputType)
        {
            foreach(var input in m_InputScheme.m_Inputs)
            {
                if(input.m_InputType == inputType)
                {
                    input.UpdateInput();
                }
            }
        }
        #endregion



//        #region Input Methods
//        void PS4Input()
//        {
//            EF_InputGlobal.Instance.horizontalInput = Input.GetAxis("Horizontal");
//            EF_InputGlobal.Instance.verticalInput = Input.GetAxis("Vertical");
//
//            EF_InputGlobal.Instance.YAxis = Input.GetAxis("6THAxis");
//            EF_InputGlobal.Instance.XAxis = Input.GetAxis("3rdAxis");
//
//            EF_InputGlobal.Instance.runPressed = Input.GetButton("Button 11");
//            EF_InputGlobal.Instance.jumpPressed = Input.GetButton("Button 1");
//            EF_InputGlobal.Instance.reloadPressed = Input.GetButtonDown("Button 0");
//
//            EF_InputGlobal.Instance.shootPressed = Input.GetButton("Button 7");
//            EF_InputGlobal.Instance.aimPressed = Input.GetButton("Button 6");
//            EF_InputGlobal.Instance.nextWeaponPressed = Input.GetButtonDown("Button 3");
//
//            EF_InputGlobal.Instance.jetpackPressed = Input.GetButton("Button 5");
//            EF_InputGlobal.Instance.pausePressed = Input.GetButtonDown("Button 9");
//            EF_InputGlobal.Instance.changeCameraPressed = Input.GetButtonDown("Button 4");
//        }
//        #endregion
    }
}

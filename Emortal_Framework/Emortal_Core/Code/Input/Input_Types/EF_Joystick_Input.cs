using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Emortal.Core
{
    [System.Serializable]
    public class EF_Joystick_Input : EF_Base_Input 
    {
        #region Variables
        public JoystickButtons runPressed = JoystickButtons.Button9;
        public JoystickButtons jumpPressed = JoystickButtons.Button0;
        public JoystickButtons jumpHold = JoystickButtons.Button0;
        public JoystickButtons reloadPressed = JoystickButtons.Button2;
        public JoystickButtons nextWeaponPressed = JoystickButtons.Button3;
        public JoystickButtons jetpackPressed = JoystickButtons.Button5;

        public string shootPressed = "10ThAxis";
        public string aimPressed = "9ThAxis";

        public JoystickButtons pausePressed = JoystickButtons.Button7;
        public JoystickButtons melePressed = JoystickButtons.Button2;
        public JoystickButtons changeCameraPressed = JoystickButtons.Button4;
        #endregion


        #region Methods
        /// <summary>
        /// Handles the input during Runtime
        /// </summary>
        protected override void HandleInput()
        {
            base.HandleInput();

            EF_InputGlobal.Instance.YAxis = Input.GetAxis(m_XAxis);
            EF_InputGlobal.Instance.XAxis = Input.GetAxis(m_YAxis);

            EF_InputGlobal.Instance.runPressed = Input.GetButton("Button " + ((int)runPressed).ToString());
            EF_InputGlobal.Instance.jumpPressed = Input.GetButton("Button " + ((int)jumpPressed).ToString());
            EF_InputGlobal.Instance.jumpHold = Input.GetButton("Button " + ((int)jumpHold).ToString());
            EF_InputGlobal.Instance.reloadPressed = Input.GetButtonDown("Button " + ((int)reloadPressed).ToString());
            EF_InputGlobal.Instance.nextWeaponPressed = Input.GetButtonDown("Button " + ((int)nextWeaponPressed).ToString());
            EF_InputGlobal.Instance.jetpackPressed = Input.GetButton("Button " + ((int)jetpackPressed).ToString());
            EF_InputGlobal.Instance.pausePressed = Input.GetButtonDown("Button " + ((int)pausePressed).ToString());
            EF_InputGlobal.Instance.changeCameraPressed = Input.GetButtonDown("Button " + ((int)changeCameraPressed).ToString());
            EF_InputGlobal.Instance.melePressed = Input.GetButtonDown("Button " + ((int)melePressed).ToString());

            EF_InputGlobal.Instance.shootPressed = Input.GetAxis(shootPressed) > 0f ? true : false;
            EF_InputGlobal.Instance.aimPressed = Input.GetAxis(aimPressed) > 0f ? true : false;

        }
        #endregion



        #if UNITY_EDITOR
        #region Editor methods
        /// <summary>
        /// Handles the editor for the Input Class.
        /// </summary>
        protected override void HandleEditor()
        {
            base.HandleEditor();

            EditorGUILayout.Space();

            runPressed = (JoystickButtons)EditorGUILayout.EnumPopup("Run Button:", runPressed);
            jumpPressed = (JoystickButtons)EditorGUILayout.EnumPopup("Jump Button:", jumpPressed);
            reloadPressed = (JoystickButtons)EditorGUILayout.EnumPopup("Reload Button:", reloadPressed);
            nextWeaponPressed = (JoystickButtons)EditorGUILayout.EnumPopup("Next Weapon Button:", nextWeaponPressed);
            jetpackPressed = (JoystickButtons)EditorGUILayout.EnumPopup("Jetpack Button:", jetpackPressed);
            pausePressed = (JoystickButtons)EditorGUILayout.EnumPopup("Pause Button:", pausePressed);
            melePressed = (JoystickButtons)EditorGUILayout.EnumPopup("Melee Button:", melePressed);
            changeCameraPressed = (JoystickButtons)EditorGUILayout.EnumPopup("Change Camera Button:", changeCameraPressed);


            shootPressed = EditorGUILayout.TextField("Shoot Axis: ", shootPressed);
            aimPressed = EditorGUILayout.TextField("Aim Axis: ", aimPressed);


            EditorGUILayout.Space();
        }
        #endregion
        #endif
    }
}

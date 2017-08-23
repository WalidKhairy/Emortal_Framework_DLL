using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Emortal.Core
{
    [System.Serializable]
    public class EF_Keyboard_Input : EF_Base_Input 
    {
        #region Variables
        public KeyCode runPressed = KeyCode.LeftShift;
        public KeyCode jumpPressed = KeyCode.Space;
        public KeyCode jumpHold = KeyCode.Space;

        public MouseButtons shootPressed = MouseButtons.leftMouse;
        public KeyCode nextWeaponPressed = KeyCode.Tab;
        public MouseButtons aimPressed = MouseButtons.RightMouse;
        public KeyCode reloadPressed = KeyCode.R;

        public KeyCode jetpackPressed = KeyCode.F;
        public KeyCode pausePressed = KeyCode.P;
        public KeyCode melePressed = KeyCode.E;
        public KeyCode changeCameraPressed = KeyCode.C;
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

            EF_InputGlobal.Instance.runPressed = Input.GetKey(runPressed);
            EF_InputGlobal.Instance.jumpPressed = Input.GetKeyDown(jumpPressed);
            EF_InputGlobal.Instance.jumpHold = Input.GetKey(jumpHold);
            EF_InputGlobal.Instance.reloadPressed = Input.GetKey(reloadPressed);

            EF_InputGlobal.Instance.shootPressed = Input.GetMouseButton((int)shootPressed);
            EF_InputGlobal.Instance.aimPressed = Input.GetMouseButton((int)aimPressed);
            EF_InputGlobal.Instance.nextWeaponPressed = Input.GetKeyDown(nextWeaponPressed);

            EF_InputGlobal.Instance.jetpackPressed = Input.GetKey(jetpackPressed);
            EF_InputGlobal.Instance.pausePressed = Input.GetKeyDown(pausePressed);
            EF_InputGlobal.Instance.melePressed = Input.GetKeyDown(melePressed);
            EF_InputGlobal.Instance.changeCameraPressed = Input.GetKeyDown(changeCameraPressed);

        }
        #endregion


        #if UNITY_EDITOR
        #region Editor methods
        /// <summary>
        /// Handles the editor for this Input
        /// </summary>
        protected override void HandleEditor()
        {
            base.HandleEditor();

            EditorGUILayout.Space();

            runPressed = (KeyCode)EditorGUILayout.EnumPopup("Run Key:", runPressed);
            jumpPressed = (KeyCode)EditorGUILayout.EnumPopup("Jump Key:", jumpPressed);
            jumpHold = (KeyCode)EditorGUILayout.EnumPopup("Jump Hold Key:", jumpHold);
            reloadPressed = (KeyCode)EditorGUILayout.EnumPopup("Reload Key:", reloadPressed);

            shootPressed = (MouseButtons)EditorGUILayout.EnumPopup("Shoot Button:", shootPressed);
            aimPressed = (MouseButtons)EditorGUILayout.EnumPopup("Aim Button: ", aimPressed);
            nextWeaponPressed = (KeyCode)EditorGUILayout.EnumPopup("Next Weapon Key:", nextWeaponPressed);

            jetpackPressed = (KeyCode)EditorGUILayout.EnumPopup("Jetpack Key:", jetpackPressed);
            pausePressed = (KeyCode)EditorGUILayout.EnumPopup("Pause Key:", pausePressed);
            melePressed = (KeyCode)EditorGUILayout.EnumPopup("Melee Key:", melePressed);
            changeCameraPressed = (KeyCode)EditorGUILayout.EnumPopup("Change Camera Key:", changeCameraPressed);

            EditorGUILayout.Space();

        }
        #endregion
        #endif
    }
}

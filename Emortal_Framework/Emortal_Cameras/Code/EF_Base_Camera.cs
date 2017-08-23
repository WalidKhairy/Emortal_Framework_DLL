using System;
using UnityEngine;

namespace Emortal.Cameras
{
    [RequireComponent(typeof(Camera))]
    public class EF_Base_Camera : MonoBehaviour
    {
        #region Variables
        [Header("Base Properties")]
        public bool canMove = true;
        public bool canRotate = true;
        public Transform m_Target;

        [Space(10f)]
        public float cursorSensitivity = 0.025f;
        public KeyCode cursorToggleButton = KeyCode.Escape;
        protected float currentSpeed = 0f;
        protected bool isMoving = false;
        #endregion

        #region Main Methods
        // Use this for initialization
        public virtual void OnEnable()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            UpdateTranslation();
            UpdateRotation();

            HandleCursor();
        }
        #endregion

        #region Custom Methods
        //Virtual Movement Methods that each Camera Overrides.
        protected virtual void UpdateTranslation() { }
        protected virtual void UpdateRotation() { }
        protected virtual void HandleCursor()
        {
            if (Input.GetKeyUp(cursorToggleButton))
            {
                Cursor.visible = !Cursor.visible;

                if(Cursor.lockState == CursorLockMode.Locked)
                {
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }
        #endregion
    }
}

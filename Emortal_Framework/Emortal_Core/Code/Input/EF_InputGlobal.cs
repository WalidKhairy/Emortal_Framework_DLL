using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Core
{
    /// <summary>
    /// Input Enums define all the enumerations that are used by the input system
    /// Using these enums the system dynamically knows which inputs to use.
    /// </summary>
    #region Input Enums
    public enum InputType
    {
        Keyboard = 0,
        Xbox = 1,
        PS4 = 2,
        Vive = 3
    }

    public enum MouseButtons
    {
        leftMouse = 0,
        MiddleMouse = 2,
        RightMouse = 1
    }

    public enum JoystickButtons
    {
        Button0 = 0,
        Button1 = 1,
        Button2 = 2,
        Button3 = 3,
        Button4 = 4,
        Button5 = 5,
        Button6 = 6,
        Button7 = 7,
        Button8 = 8,
        Button9 = 9,
        Button10 = 10,
        Button11 = 11,
        Buttton12 = 12,
        Button13 = 13,
        Button14 = 14,
        Button15 = 15,
        Button16 = 16,
        Button17 = 17,
        Button18 = 18,
        Button19 = 19,
    }
    #endregion


    /// <summary>
    /// Input Global gives you a static class you can always access to receive
    /// inputs from any type of input that has been set up in the Input Designer
    /// </summary>
    #region Static Class
    public class EF_InputGlobal
    {
        private static EF_InputGlobal instance;

        public float horizontalInput = 0.0f;
        public float verticalInput = 0.0f;
        public float XAxis = 0.0f;
        public float YAxis = 0.0f;
        public bool runPressed = false;
        public bool jumpPressed = false;
        public bool jumpHold = false;

        public bool shootPressed = false;
        public bool nextWeaponPressed = false;
        public bool aimPressed = false;
        public bool reloadPressed = false;

        public bool jetpackPressed = false;
        public bool pausePressed = false;
        public bool melePressed = false;
        public bool changeCameraPressed = false;

        public static EF_InputGlobal Instance
        {
            get
            {
                if (instance == null)
                    instance = new EF_InputGlobal();

                return instance;
            }
        }
    }
    #endregion

}

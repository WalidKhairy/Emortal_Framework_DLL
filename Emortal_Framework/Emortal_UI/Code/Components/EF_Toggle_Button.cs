using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Emortal.UI
{
    public class OnToggleButton : UnityEvent<bool>{}
    public class EF_Toggle_Button : MonoBehaviour 
    {
        #region Variables
        [Header("UI Elements")]
        public Text m_ButtonText;
        public Image m_ButtonImage;

        [Header("Toggle Properties")]
        public bool m_StartValue = false;
        [Space]
        public Color m_OnColor = Color.green;
        public string m_OnText = "On";
        public Color m_TextOnColor = Color.gray;
        [Space]
        [Space]
        public Color m_OffColor = Color.red;
        public string m_OffText = "Off";
        public Color m_TextOffColor = Color.white;

        [Header("Events")]
        public OnToggleButton onToggleButton = new OnToggleButton();


        private bool toggleValue = false;
        public bool ToggleValue{get{return toggleValue;}}
        #endregion

        #region Main Methods
        void Start()
        {
            toggleValue = m_StartValue;
            HandleGraphics();
        }

        public void ToggleButton()
        {
            //handle the toggle 
            toggleValue = !toggleValue;
            HandleGraphics();

            //throw the toggle event
            if(onToggleButton != null)
            {
                onToggleButton.Invoke(toggleValue);
            }
        }

        void HandleGraphics()
        {
            if(m_ButtonText && m_ButtonImage)
            {
                switch(toggleValue)
                {
                    case false:
                        m_ButtonText.text = m_OffText;
                        m_ButtonText.color = m_TextOffColor;
                        m_ButtonImage.color = m_OffColor;
                        break;

                    case true:
                        m_ButtonText.text = m_OnText;
                        m_ButtonText.color = m_TextOnColor;
                        m_ButtonImage.color = m_OnColor;
                        break;

                    default:
                        break;
                }
            }
        }
        #endregion
    }
}

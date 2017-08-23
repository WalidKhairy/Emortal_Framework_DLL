using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Emortal.UI
{
    public class EF_Header_Manager : MonoBehaviour 
    {
        #region Variables
        [Header("Header Components")]
        public Text m_TitleText;
        public Button m_BackButton;
        public Button m_InfoButton;
        public Button m_CloseButton;
        public Button m_MenuButton;
        public Button m_LogoutButton;
        public GameObject m_Logo;
        public GameObject m_MenuGrp;

        private string currentTitle;
        #endregion

        #region Main Methods
        void Start()
        {
            if(m_MenuGrp)
            {
                m_MenuGrp.SetActive(true);    
            }
        }

        public void HandleHeader(EF_Base_Screen aScreen)
        {
            if(aScreen)
            {
                //Check to see if we want the Header first
                gameObject.SetActive(aScreen.m_ScreenData.showHeader);
                if(!aScreen.m_ScreenData.showHeader)
                {
                    return;
                }


                //Set the Title
                currentTitle = aScreen.m_ScreenData.screenTitle;
                if(m_TitleText && !string.IsNullOrEmpty(currentTitle))
                {
                    m_TitleText.text = currentTitle;
                }

                if(m_BackButton)
                {
                    m_BackButton.gameObject.SetActive(aScreen.m_ScreenData.allowBackButton);
                }

                if(m_InfoButton)
                {
                    m_InfoButton.gameObject.SetActive(aScreen.m_ScreenData.showInfoButton);
                }

                if(m_CloseButton)
                {
                    m_CloseButton.gameObject.SetActive(aScreen.m_ScreenData.showCloseButton);
                }

                if(m_MenuButton)
                {
                    m_MenuButton.gameObject.SetActive(aScreen.m_ScreenData.showMenuButton);
                }

                if(m_Logo)
                {
                    m_Logo.gameObject.SetActive(aScreen.m_ScreenData.showLogo);
                }

                if(m_LogoutButton)
                {
                    m_LogoutButton.gameObject.SetActive(aScreen.m_ScreenData.showLogoutButton);
                }
            }
        }
        #endregion
    }
}

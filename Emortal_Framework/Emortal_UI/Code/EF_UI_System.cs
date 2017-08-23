using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Emortal.Core;
using UnityEngine.Events;

namespace Emortal.UI
{
    public class SwitchedScreenEvent : UnityEvent<EF_Base_Screen>{}

    [RequireComponent(typeof(AudioSource))]
    public class EF_UI_System : MonoBehaviour 
    {
        #region Variables
        [Header("Main Properties")]
        public Image m_FadeOverlay;
        public GameObject m_BGImage;
        public GameObject m_PopupPanel;
        public GameObject m_HeaderPanel;

        [Header("Fade Properties")]
        public float m_FadeInDuration = 1f;
        public float m_FadeOutDuration = 1f;

        [Header("Screens")]
        public EF_Base_Screen m_StartScreen;

        [Header("Events")]
        public SwitchedScreenEvent OnSwitchedScreen = new SwitchedScreenEvent();

        public EF_Base_Screen m_CurrentScreen { get; private set; }
        private EF_Base_Screen m_PreviousScreen;
        private List<EF_Base_Screen> m_BackStack = new List<EF_Base_Screen>();
        private bool goingBack = false;
        private EF_Screen_Data currentScreenData;

        private Component[] foundScreens = new Component[0];
        private EF_Popup_Manager popupManager;
        #endregion

        #region Main Methods
    	// Use this for initialization
    	void Start () 
        {
            GetAllScreens();

            if(m_StartScreen)
            {
                SwitchScreens(m_StartScreen);
            }

            InitFader();
            FadeIn();
    	}

        public void SwitchScreens(EF_Base_Screen aScreen)
        {
            if(aScreen)
            {
                //Close the current Screen
                if(m_CurrentScreen)
                {
                    m_CurrentScreen.CloseScreen();
                    m_PreviousScreen = m_CurrentScreen;

                    if(!goingBack)
                    {
                        AddToBackStack(m_PreviousScreen);
                    }
                    goingBack = false;
                }


                //Start the Next Screen
                m_CurrentScreen = aScreen;
                aScreen.gameObject.SetActive(true);
                m_CurrentScreen.StartScreen();
                currentScreenData = m_CurrentScreen.m_ScreenData;

               

                //Fire the Switched Screen Event
                if(OnSwitchedScreen != null)
                {
                    OnSwitchedScreen.Invoke(m_CurrentScreen);
                }

                HandleBGImage();
            }
        }
        #endregion

        #region Utility Methods
        void InitFader()
        {
            if(m_FadeOverlay)
            {
                m_FadeOverlay.gameObject.SetActive(true);    
            }
        }

        public void LoadScene(int sceneIndex)
        {
            StartCoroutine(WaitToLoadScene(sceneIndex));
        }

        IEnumerator WaitToLoadScene(int sceneIndex)
        {
            FadeOut();

            yield return new WaitForSeconds(m_FadeOutDuration);

            if(EF_Game_Manager.Instance != null)
            {
                EF_Game_Manager.Instance.LoadScene(sceneIndex);
            }
        }

        void FadeIn()
        {
            if(m_FadeOverlay)
            {
                m_FadeOverlay.gameObject.SetActive(true);
                m_FadeOverlay.CrossFadeAlpha(0, m_FadeInDuration, false);
            }
        }

        void FadeOut()
        {
            if(m_FadeOverlay)
            {
                m_FadeOverlay.CrossFadeAlpha(1, m_FadeInDuration, false);
            }
        }

        public void AddToBackStack(EF_Base_Screen aScreen)
        {
            if(aScreen && m_BackStack != null)
            {
                m_BackStack.Add(aScreen);
            }
        }

        public void GoToPreviousScreen()
        {
            if(m_BackStack.Count > 0)
            {
                goingBack = true;
                EF_Base_Screen screen = m_BackStack[m_BackStack.Count - 1];
                m_BackStack.RemoveAt(m_BackStack.Count - 1);
                SwitchScreens(screen);
            }
        }

        void HandleBGImage()
        {
            if(m_BGImage)
            {
                m_BGImage.SetActive(currentScreenData.showBG);
            }
        }

        void GetAllScreens()
        {
            foundScreens = GetComponentsInChildren<EF_Base_Screen>(true);
            foreach(EF_Base_Screen screen in foundScreens)
            {
                screen.gameObject.SetActive(true);
            }

            if(m_PopupPanel)
            {
                m_PopupPanel.SetActive(true);
                popupManager = m_PopupPanel.GetComponent<EF_Popup_Manager>();
            }

            if(m_HeaderPanel)
            {
                m_HeaderPanel.SetActive(true);
                OnSwitchedScreen.AddListener(m_HeaderPanel.GetComponent<EF_Header_Manager>().HandleHeader);
            }
        }
        #endregion


        #region Popup Methods
        public void ShowPopup(int popupID)
        {
            if(popupManager)
            {
                popupManager.SetPopupData(popupID);
                popupManager.ShowPopup();
            }
        }
        #endregion
    }
}

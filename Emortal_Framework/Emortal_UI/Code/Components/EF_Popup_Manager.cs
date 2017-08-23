using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Emortal.UI
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CanvasGroup))]
    public class EF_Popup_Manager : MonoBehaviour 
    {
        #region Variables
        [Header("Popup Elements")]
        public Text m_PopupTitleText; 

        [Header("Popup Screens")]
        public List<PopupData> m_Screens = new List<PopupData>();

        private Animator animator;
        #endregion

        #region Main Methods
    	// Use this for initialization
    	void Start () 
        {
            animator = GetComponent<Animator>();
    	}
        #endregion


        #region Helper Methods
        public void ShowPopup()
        {
            if(animator)
            {
                animator.SetTrigger("show");
            }
        }

        public void HidePopup()
        {
            if(animator)
            {
                animator.SetTrigger("hide");
            }
        }

        public void SetPopupData(int popupID)
        {
//            m_PopupTitleText.text = aTitle;

            if(popupID < m_Screens.Count)
            {
                for(int i = 0; i < m_Screens.Count; i++)
                {
                    if(m_Screens[i].screenGO)
                    {
                        if(i == popupID)
                        {
                            if(m_PopupTitleText)
                            {
                                m_PopupTitleText.text = m_Screens[i].title;
                            }
                            m_Screens[i].screenGO.SetActive(true);
                        }
                        else
                        {
                            m_Screens[i].screenGO.SetActive(false);
                        }
                    }
                }
            }

            ShowPopup();
        }
        #endregion
    }

    [System.Serializable]
    public class PopupData
    {
        public string title = "Popup Title";
        public GameObject screenGO;
    }
}

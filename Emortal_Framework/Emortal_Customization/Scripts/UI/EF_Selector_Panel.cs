using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Emortal.Customization
{
    public class onCategorySwitch : UnityEvent<EF_Customizer_Category>{}
    public class EF_Selector_Panel : MonoBehaviour 
    {
        #region Variables
        public Text m_TitleText;
        public GameObject m_LeftButton;
        public GameObject m_RightButton;

        public int currentID = 0;

        public onCategorySwitch OnCategorySwitch = new onCategorySwitch();
        #endregion


        #region Main Methods
        #endregion


        #region Utility Methods
        public void SwitchCategory(List<EF_Customizer_Category> categories, int direction)
        {
            switch(direction)
            {
                case -1:
                    currentID--;
                    break;

                case 1:
                    currentID++;
                    break;

                default:
                    break;
            }

            currentID = Mathf.Clamp(currentID, 0, categories.Count - 1);
            HandleButtons(categories.Count);
            GetTitle(categories[currentID]);

            //Set the active bool on each category
            foreach(var category in categories)
            {
                if(category == categories[currentID])
                {
                    category.m_isActive = true;
                }
                else
                {
                    category.m_isActive = false;
                }
            }

            //Throw the event
            if(OnCategorySwitch != null)
            {
                OnCategorySwitch.Invoke(categories[currentID]);
            }
        }

        void HandleButtons(int categoryCount)
        {
            if(m_RightButton && m_LeftButton)
            {
                m_RightButton.SetActive(true);
                m_LeftButton.SetActive(true);

                if(currentID == categoryCount-1)
                {
                    m_RightButton.SetActive(false);
                }
                else if(currentID == 0)
                {
                    m_LeftButton.SetActive(false);
                }
            }
        }

        void GetTitle(EF_Customizer_Category aCategory)
        {
            if(aCategory != null)
            {
                string rawName = aCategory.gameObject.name;
                string[] splitName = rawName.Split('_');

                if(m_TitleText)
                {
                    m_TitleText.text = splitName[0].ToUpper(); 
                }
            }
        }
        #endregion
    }
}

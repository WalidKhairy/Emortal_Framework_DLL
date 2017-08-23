using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Emortal.UI;

namespace Emortal.Customization
{
    public class EF_Items_Panel : MonoBehaviour 
    {
        #region Variables
        public EF_Item_Button m_ItemButton;
        public RectTransform m_ContentPanel;

        public List<EF_Item_Button> currentButtons = new List<EF_Item_Button>();
        #endregion

        #region Main Methods
        #endregion


        #region Utility Methods
        public void BuildItems(EF_Customizer_Category aCatagory)
        {
//            Debug.Log("Building Items");
            ClearItems();


            if(m_ItemButton && m_ContentPanel)
            {
                for(int i = 0; i < aCatagory.m_Items.Count; i++)
                {
                    EF_Item_Button curButton = (EF_Item_Button)Instantiate(m_ItemButton, m_ContentPanel);

                    //Set up the button
                    curButton.id = i;
                    curButton.m_Image.sprite = aCatagory.m_Items[i].m_Icon;
                    curButton.m_Text.text = aCatagory.m_Items[i].name;
                    curButton.InitButton();

                    //Set up the Click Event
                    curButton.onClickID.AddListener(aCatagory.UpdateItems);
                    currentButtons.Add(curButton);
                }
            }
        }

        void ClearItems()
        {
            foreach(var item in currentButtons)
            {
                item.onClickID.RemoveAllListeners();
                Destroy(item.gameObject);
            }

            currentButtons.Clear();
        }
        #endregion
    }
}

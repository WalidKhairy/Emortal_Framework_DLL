using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Emortal.Customization
{
    public class EF_Customization_Panel : EF_BaseCustomization_Panel 
    {
        #region Variables
        [Header("Selector Panels")]
        public EF_Selector_Panel m_SelectorPanel;

        private int currentCateogryID;
        #endregion

        #region Main Methods
    	// Use this for initialization
    	void Start () 
        {
            if(m_SelectorPanel)
            {
                m_SelectorPanel.OnCategorySwitch.AddListener(LoadCategoryItems);
                SwitchCategory(-1);
            }
    	}
        #endregion


        #region Utility Methods
        public void SwitchCategory(int direction)
        {
            if(m_SelectorPanel && m_Character)
            {
                m_SelectorPanel.SwitchCategory(m_Character.m_Categories, direction);
            }
        }
        #endregion
    }
}

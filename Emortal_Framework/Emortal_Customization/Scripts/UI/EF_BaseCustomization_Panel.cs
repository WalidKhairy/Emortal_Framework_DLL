using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Customization
{
    public class EF_BaseCustomization_Panel : MonoBehaviour 
    {
        #region Variables
        [Header("Main Properties")]
        public EF_CharacterCustomizer m_Character;

        [Header("UI Panels")]
        public EF_Items_Panel m_ItemsPanel;
        #endregion


        #region Main Methods
        public virtual void LoadCategoryItems(EF_Customizer_Category aCategory)
        {
            //Debug.Log("Loading Items in: " + aCategory.gameObject.name);
            if(m_ItemsPanel && aCategory)
            {
                m_ItemsPanel.BuildItems(aCategory);
            }
        }
        #endregion
    }
}

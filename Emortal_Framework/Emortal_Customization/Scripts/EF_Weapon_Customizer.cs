using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Customization
{
    public class EF_Weapon_Customizer : MonoBehaviour 
    {
        #region Variables
        public EF_Customizer_Category m_Category;
        public EF_Customizer_Item m_StartItem;
        #endregion

        #region Main Methods
    	// Use this for initialization
    	void Start () 
        {
            if(m_StartItem)
            {
                m_StartItem.gameObject.SetActive(true);
            }
    	}
    	
    	// Update is called once per frame
    	void Update () 
        {
    		
    	}
        #endregion
    }
}

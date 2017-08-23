using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Customization
{
    [RequireComponent(typeof(EF_Customizer_Category))]
    public class EF_Face_Manager : MonoBehaviour 
    {
        #region Variables
        [HideInInspector]
        public EF_Customizer_Category categoryScript;
        [HideInInspector]
        public EF_Customizer_Item startHead;
        #endregion

        #region Main Methods
    	// Use this for initialization
    	void Start () 
        {
            if(!categoryScript)
            {
                categoryScript = GetComponent<EF_Customizer_Category>();
            }

            if(startHead)
            {
                categoryScript.UpdateItems(startHead.itemID);
            }
    	}

        public void InitFaceManager()
        {
            categoryScript = GetComponent<EF_Customizer_Category>();
            if(categoryScript.m_Items.Count > 0)
            {
                startHead = categoryScript.m_Items[0];
            }
        }
        #endregion
    }
}

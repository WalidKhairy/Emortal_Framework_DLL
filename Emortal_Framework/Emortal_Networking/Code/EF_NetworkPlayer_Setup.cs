using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Emortal.Networking
{
    public class EF_NetworkPlayer_Setup : NetworkBehaviour
    {
        #region Variables
        [SerializeField]
        private Behaviour[] m_ComponentsToDisable = new Behaviour[0];
        #endregion


        #region Methods
    	// Use this for initialization
    	void Start () 
        {
            if(m_ComponentsToDisable.Length > 0 && !isLocalPlayer)
            {
                for(int i = 0; i < m_ComponentsToDisable.Length; i++)
                {
                    m_ComponentsToDisable[i].enabled = false;
                }
            }
    	}
        #endregion

    }
}

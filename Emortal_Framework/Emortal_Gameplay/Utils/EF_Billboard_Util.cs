using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Gameplay
{
    public class EF_Billboard_Util : MonoBehaviour 
    {
        #region Variables
        public bool m_IsFlatVector = true;
        public bool m_ReverseDir = true;
        public string m_TargetTag = "Player";

        private GameObject m_FoundTarget;
        #endregion

        #region Methods
    	// Use this for initialization
    	void Start () 
        {
            m_FoundTarget = GameObject.FindGameObjectWithTag(m_TargetTag);	
    	}
    	
    	// Update is called once per frame
    	void Update () 
        {
            if(m_FoundTarget)
            {
                Vector3 dir = m_FoundTarget.transform.position - transform.position;
                dir.y = m_IsFlatVector ? 0f : dir.y;

                if(m_ReverseDir)
                {
                    dir = -dir;
                }

                transform.rotation = Quaternion.LookRotation(dir);
            }
    	}
        #endregion
    }
}

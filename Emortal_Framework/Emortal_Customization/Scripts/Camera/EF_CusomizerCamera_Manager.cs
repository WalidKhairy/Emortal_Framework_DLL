using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Customization
{
    public class EF_CusomizerCamera_Manager : MonoBehaviour 
    {
        #region Variables
        public Transform m_StartPosition;
        public Transform m_EditPosition;
        public float m_SmoothTime = 0.25f;

        private Vector3 m_WantedPosition;
        private Vector3 refVector;
        #endregion

        #region Main Methods
    	// Use this for initialization
    	void Start () 
        {
            if(m_StartPosition)
            {
                m_WantedPosition = m_StartPosition.position;
                transform.position = m_WantedPosition;
            }
    	}
    	
    	// Update is called once per frame
    	void Update () 
        {
            transform.position = Vector3.SmoothDamp(transform.position, m_WantedPosition, ref refVector, m_SmoothTime);
    	}
        #endregion


        #region Helper Methods
        public void SetPosition(int positionId)
        {
            switch(positionId)
            {
                case 0:
                    m_WantedPosition = m_StartPosition.position;
                    break;

                case 1:
                    m_WantedPosition = m_EditPosition.position;
                    break;

                default:
                    break;
            }
        }
        #endregion
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Gameplay
{
    public class EF_FollowRotation_Util : MonoBehaviour 
    {
        #region Variables
        public Transform m_Target;
        public float m_Speed;
        public bool onlyY;
        #endregion

        #region Methods
    	// Update is called once per frame
    	void Update () 
        {
            Quaternion wantedRotation;
            if(onlyY)
            {
                wantedRotation = Quaternion.Euler(transform.eulerAngles.x, m_Target.eulerAngles.y, transform.eulerAngles.z);
            }
            else
            {
                wantedRotation = m_Target.rotation;
            }

            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * m_Speed);
    	}
        #endregion
    }
}

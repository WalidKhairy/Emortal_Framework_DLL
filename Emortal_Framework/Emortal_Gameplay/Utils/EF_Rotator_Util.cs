using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Gameplay
{
    public class EF_Rotator_Util : MonoBehaviour 
    {
        #region Variables
        public Vector3 m_Rotation = Vector3.zero;
        public Space m_Space;
        #endregion

        #region Methods
    	// Update is called once per frame
    	void Update () 
        {
            transform.Rotate(m_Rotation * Time.deltaTime, m_Space);
    	}
        #endregion
    }
}

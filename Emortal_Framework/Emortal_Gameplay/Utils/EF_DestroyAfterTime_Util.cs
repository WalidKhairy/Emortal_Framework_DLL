using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Gameplay
{
    public class EF_DestroyAfterTime_Util : MonoBehaviour 
    {
        #region Variables
        public float m_LifeSpan = 2f;

        private float m_StartTime;
        #endregion

        #region Main Methods
        // Use this for initialization
        void Start () 
        {
            m_StartTime = Time.time;
        }

        // Update is called once per frame
        void Update () 
        {
            if(Time.time > m_StartTime + m_LifeSpan)
            {
                Destroy(gameObject);
            }
        }
        #endregion
    }
}

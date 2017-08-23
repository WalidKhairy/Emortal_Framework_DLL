using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Gameplay
{
    public class EF_Door_Base : MonoBehaviour 
    {
        #region Variables
        public Vector3 m_OpenPosition;
        public float m_Speed = 10f;

        protected Vector3 m_StartPosition;
        protected Vector3 m_WantedPosition;
        protected Vector3 m_RefVelocity;
        #endregion

        #region Methods
    	// Use this for initialization
    	void Start () 
        {
            m_StartPosition = transform.localPosition;
    	}
            

        public virtual void OpenDoor()
        {
            m_WantedPosition = m_OpenPosition;
            Debug.Log(m_WantedPosition);
            StopCoroutine("UpdateDoor");
            StartCoroutine("UpdateDoor");
        }

        public virtual void CloseDoor()
        {
            m_WantedPosition = m_StartPosition;
            StopCoroutine("UpdateDoor");
            StartCoroutine("UpdateDoor");
        }

        protected IEnumerator UpdateDoor()
        {
            while(transform.position != m_WantedPosition)
            {
                transform.localPosition = Vector3.SmoothDamp(transform.localPosition, m_WantedPosition, ref m_RefVelocity, m_Speed);
                yield return null;
            }

            yield break;
        }
        #endregion


        #region Utility Methods
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.35f);
        }
        #endregion
    }
}

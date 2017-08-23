using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Cameras
{
    public class EF_TopDown_Camera : EF_Base_Camera 
    {
        #region Variables
        [Header("Top Down Properties")]
        public float m_Height = 10f;
        public float m_Distance = 10f;
        public float m_YRotation = 45f;
        public float m_LeadDistance = 2f;

        private Vector3 finalLead;
        private Vector3 m_LastPosition;
        #endregion

        #region Main Methods
        protected override void UpdateTranslation()
        {
            if(m_Target)
            {

                //Build the world space Camera Position
                Vector3 worldPosition = ((Vector3.back * m_Distance) + (Vector3.up * m_Height));
                worldPosition = Quaternion.AngleAxis(m_YRotation, Vector3.up) * worldPosition;

                //Apply the World Position
                Vector3 flatTargetPosition = new Vector3(m_Target.position.x, 0f, m_Target.position.z);
                Vector3 wantedPosition = flatTargetPosition + worldPosition; 
                transform.position = wantedPosition;


                //Calculate the velocity of the target without an Rigibody
                Vector3 targetVelocity = m_Target.position - m_LastPosition;
                targetVelocity.y = 0f;
                Debug.DrawRay( m_Target.position, targetVelocity * 5f, Color.red);


                //Create a lead distance based off of a Speed
                finalLead = Vector3.Lerp(finalLead, m_Target.forward * (m_LeadDistance * targetVelocity.magnitude), Time.deltaTime * 2f);
                transform.LookAt(m_Target.position + finalLead);


                //Set the last position to get the velocity from the target
                m_LastPosition = m_Target.position;

            }
        }
        #endregion
    }
}

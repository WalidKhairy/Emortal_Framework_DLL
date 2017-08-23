using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Destruction
{
    public class RadialRigidbodyActivation : MonoBehaviour 
    {
        #region Variables
        public LayerMask m_ActivationLayer;
        public float m_Range = 5;
        public float m_Speed = 5;
        #endregion

        #region Methods
        void OnEnable()
        {
            HandleActivation(transform.position); 
        }

        void OnCollisionEnter(Collision col)
        {
            //HandleActivation(col.contacts[0].point);
        }
        #endregion



        #region Utility Methods
        void HandleActivation(Vector3 pos)
        {
            var colliders = Physics.OverlapSphere(pos, m_Range, m_ActivationLayer);
            foreach(var col in colliders)
            {
                Rigidbody rb = col.GetComponent<Rigidbody>();
                float distance = Vector3.Distance(transform.position, rb.transform.position);

                StartCoroutine(DelayActivation(rb, distance / m_Speed));
            }
        }

        IEnumerator DelayActivation(Rigidbody rb, float delay)
        {
            yield return new WaitForSeconds(delay);
            rb.isKinematic = false;
        }
        #endregion
    }
}

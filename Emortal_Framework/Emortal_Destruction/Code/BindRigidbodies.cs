using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Destruction
{
    public class BindRigidbodies : MonoBehaviour 
    {
        #region Variables
        public LayerMask rbLayer;
        public float m_Radius = 1f;
        public float breakForce = Mathf.Infinity;
        public float breakTorque = Mathf.Infinity;
        #endregion



        #region Methods
    	// Use this for initialization
    	void Awake () 
        {
            var colliders = Physics.OverlapSphere(transform.position, m_Radius, rbLayer);

            for(int i = 0; i < colliders.Length - 1; i++)
            {
                FixedJoint joint = colliders[i].gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = colliders[i+1].GetComponent<Rigidbody>();
                joint.breakForce = breakForce;
                joint.breakTorque = breakTorque;
            }

            Destroy(gameObject);
    	}

        void OnDrawGizmos()
        {
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(Vector3.zero, m_Radius);
        }
        #endregion
    }
}

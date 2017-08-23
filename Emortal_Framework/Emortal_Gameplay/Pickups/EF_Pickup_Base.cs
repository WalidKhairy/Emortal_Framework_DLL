using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Emortal.Gameplay
{
    [RequireComponent(typeof(AudioSource))]
    public class EF_Pickup_Base : MonoBehaviour 
    {
        
        #region Variables
        /// <summary>
        /// Public Variables
        /// </summary>
        [Header("Base Properties")]
        public Collider m_Collider;
        public string m_TargetTag;

        [Header("Pickup Event")]
        public UnityEvent PickupEvent = new UnityEvent();

        /// <summary>
        /// Private Variables
        /// </summary>
        public string m_ColliderType;
        #endregion




        #region Main Methods
    	// Use this for initialization
    	void Start () 
        {
            SetCollider();
    	}

        void OnTriggerEnter(Collider other)
        {
            ApplyPickup(other.gameObject);
        }

        protected virtual void ApplyPickup(GameObject other)
        {
            if(PickupEvent != null)
            {
                PickupEvent.Invoke();
            }
        }
        #endregion




        #region Custom Methods
        void SetCollider()
        {
            if(!m_Collider)
            {
                m_Collider = gameObject.AddComponent<SphereCollider>();
                m_Collider.isTrigger = true;
                m_ColliderType = GetColliderType();
            }
            else
            {
                m_Collider.isTrigger = true;    
                m_ColliderType = GetColliderType();
            }
        }

        string GetColliderType()
        {
            string colliderType = "";
            colliderType = m_Collider.GetType().ToString();

            int start = colliderType.IndexOf(".");
            string finalType = colliderType.Substring(start + 1);


            return finalType;
        }
        #endregion





        #region Gizmos
        void OnDrawGizmos()
        {
            Matrix4x4 oldMatrix = Gizmos.matrix;
            Gizmos.matrix = transform.localToWorldMatrix;


            SetCollider();


            if(m_Collider)
            {
                if(m_ColliderType == "SphereCollider")
                {
                    SphereCollider curCollider = (SphereCollider)m_Collider;
                    Color sphereColor = new Color(1f, 0f, 0f, 0.25f);
                    Color wireColor = new Color(1f, 0f, 0f, 1f);

                    Gizmos.color = sphereColor;
                    Gizmos.DrawSphere(Vector3.zero, curCollider.radius);
                    Gizmos.color = wireColor;
                    Gizmos.DrawWireSphere(Vector3.zero, curCollider.radius);
                }
                else if(m_ColliderType == "BoxCollider")
                {
                    BoxCollider curCollider = (BoxCollider)m_Collider;
                    Color sphereColor = new Color(1f, 0f, 0f, 0.25f);
                    Color wireColor = new Color(1f, 0f, 0f, 1f);

                    Gizmos.color = sphereColor;
                    Gizmos.DrawCube(Vector3.zero, curCollider.size);
                    Gizmos.color = wireColor;
                    Gizmos.DrawWireCube(Vector3.zero, curCollider.size);
                }
            }


            Gizmos.matrix = oldMatrix;
        }
        #endregion
    }




    /// <summary>
    /// Use this struct to pass pickup data between the receiver
    /// and the pickup.  
    /// </summary>
    [System.Serializable]
    public struct PickupData
    {
        public GameObject m_PickupObject;
        public float m_Value;
    }
}

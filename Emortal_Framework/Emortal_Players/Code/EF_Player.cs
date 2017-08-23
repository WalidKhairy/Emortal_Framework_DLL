using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Players
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(Rigidbody))]
    public class EF_Player : MonoBehaviour 
    {
        #region Variables
        public EF_Player_Config m_PlayerConfig;

        private AudioSource aSource;
        private Rigidbody rb;

        public bool isGrounded = true;
        public bool IsGrounded{get{return isGrounded;}}

        private Collider aCollider;
        #endregion

        #region Main Methods
    	// Use this for initialization
    	void Start () 
        {
            aSource = GetComponent<AudioSource>();
            rb = GetComponent<Rigidbody>();
            aCollider = GetComponent<Collider>();

            if(m_PlayerConfig != null)
            {
                m_PlayerConfig.InitConfig();
            }
    	}

        void OnDisable()
        {
            if(m_PlayerConfig != null)
            {
                m_PlayerConfig.DisableConfig();
            }
        }
    	
    	// Update is called once per frame
    	void FixedUpdate () 
        {
            if(m_PlayerConfig != null)
            {
                m_PlayerConfig.UpdateConfig(this);
            }
                
    	}

        public void ResetPlayer()
        {
            if(m_PlayerConfig != null)
            {
                m_PlayerConfig.ResetConfig();
            }
        }
        #endregion

        #region Collisions
        void OnCollisionEnter(Collision col)
        {
//            Debug.Log("Collided with something!");
            CheckGrounded(col);
        }

        void OnCollisionExit(Collision col)
        {
            CheckGrounded(col);
        }
        #endregion


        #region Utility Methods
        void CheckGrounded(Collision col)
        {
            //Fire a ray down from the middle of the player and check for a hit
//            RaycastHit groundHit;
            if(Physics.Linecast(aCollider.bounds.center, aCollider.bounds.center + (Vector3.down * 1.15f)))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
        #endregion
    }
}

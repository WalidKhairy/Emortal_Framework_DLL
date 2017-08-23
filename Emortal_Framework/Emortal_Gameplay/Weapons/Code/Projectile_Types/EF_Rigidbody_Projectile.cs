using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Gameplay
{
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class EF_Rigidbody_Projectile : EF_Base_Projectile
    {

        #region Variables
        private Rigidbody m_RB;
        #endregion

        #region Main Methods
        // Use this for initialization
        void Start () 
        {
            m_RB = GetComponent<Rigidbody>();
            FireProjectile();
        }
        #endregion



        #region Collision Methods
        void OnCollisionEnter(Collision other)
        {
            other.gameObject.SendMessage("ApplyDamage", SendMessageOptions.DontRequireReceiver);
            HandleHitEffect(other.contacts[0].point);
            HandleHitClip();
        }
        #endregion



        #region Custom Methods
        public override void FireProjectile()
        {
            if(m_RB)
            {
                m_RB.AddForce(transform.forward * m_Speed, ForceMode.Impulse);
            }
        }
        #endregion




    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Gameplay
{
    [RequireComponent(typeof(AudioSource))]
    public class EF_Base_Projectile : MonoBehaviour 
    {
        #region Variables
        [Header("Base Properties")]
        public float m_Speed = 20f;
        public float m_DamageAmount = 1f;

        [Header("Projectile FX")]
        public GameObject m_HitEffect;
        public AudioClip m_HitClip;


        private AudioSource m_ASource;
        #endregion



        #region Main Methods
        void OnEnable()
        {
            m_ASource = GetComponent<AudioSource>();
        }
        #endregion



        #region Custom Methods
        public virtual void FireProjectile(){}
        public virtual void HandleHitEffect(Vector3 aPosition)
        {
            if(m_HitEffect)
            {
                Instantiate(m_HitEffect, aPosition, Quaternion.identity);
            }
        }

        public virtual void HandleHitClip()
        {
            if(m_ASource && m_HitClip)
            {
                m_ASource.PlayOneShot(m_HitClip, 1f);
            }
        }
        #endregion
    }
}

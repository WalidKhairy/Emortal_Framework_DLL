
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Emortal.Core;

namespace Emortal.Gameplay
{
    public enum EF_WeaponType
    {
        Single = 0,
        RapidFire = 1,
        Projectile = 3
    }


    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(Animator))]
    public class EF_Base_Weapon : MonoBehaviour 
    {

        #region Variables
        [Header("Base Properties")]
        public bool m_AllowFire = true;
        public int m_AmmoCount = 15;

        [Header("UI Properties")]
        public Text m_BulletCountText;

        [Header("Audio Properties")]
        public AudioClip m_FireClip;
        public AudioClip m_ReloadClip;
        public AudioClip m_NoAmmoClip;

        [Header("FX Properties")]
        public Vector3 m_MuzzlePosition;

        [Header("Attach Positions")]
        public Vector3 m_GripPosition;

        [Header("Events")]
        public UnityEvent OnFire = new UnityEvent();

        protected Animator animator;
        protected AudioSource aSource;

        protected int currentAmmoCount = 0;
        #endregion




        #region Main Methods
        public virtual void Start()
        {
            animator = GetComponent<Animator>();
            aSource = GetComponent<AudioSource>();

            currentAmmoCount = m_AmmoCount;
        }

        void Update()
        {
            if(m_AllowFire && EF_InputGlobal.Instance != null)
            {
                if(EF_InputGlobal.Instance.shootPressed)
                {
                    FireWeapon();
                }

                if(EF_InputGlobal.Instance.reloadPressed)
                {
                    ReloadWeapon();
                }
            }
        }
        #endregion




        #region Custom Methods
        public void FireWeapon()
        {
            HandleWeaponFire();
        }

        //put this into the Scriptable Object
        protected virtual void HandleWeaponFire()
        {
            
            if(currentAmmoCount > 0)
            {
                HandleAudioClip(m_FireClip);
                if(OnFire != null)
                {
                    OnFire.Invoke();
                }

                CheckRaycast();

                //Handle the World Space UI
                currentAmmoCount -= 1;
                currentAmmoCount = Mathf.Clamp(currentAmmoCount, 0, m_AmmoCount);
                HandleWeaponUI();

            }
            else
            {
                HandleAudioClip(m_NoAmmoClip);
            }
        }


        protected virtual void CheckRaycast(){}
        public virtual void ReloadWeapon()
        {
            if(currentAmmoCount < m_AmmoCount)
            {
                currentAmmoCount = m_AmmoCount;
                HandleWeaponUI();
                HandleAudioClip(m_ReloadClip);
            }
        }

        protected virtual void HandleWeaponUI()
        {
            if(m_BulletCountText)
            {
                m_BulletCountText.text = currentAmmoCount.ToString();
            }
        }

        protected virtual void HandleAudioClip(AudioClip aClip)
        {
            if(aSource && aClip)
            {
                
                aSource.PlayOneShot(aClip);
            }
        }
        #endregion



        #region Utility Methods
        void OnDrawGizmos()
        {
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(m_MuzzlePosition, 0.05f);
            Gizmos.color = Color.white;

            Gizmos.color = Color.magenta;
            Gizmos.DrawSphere(m_GripPosition, 0.05f);
            Gizmos.color = Color.white;
        }
        #endregion
    }
}

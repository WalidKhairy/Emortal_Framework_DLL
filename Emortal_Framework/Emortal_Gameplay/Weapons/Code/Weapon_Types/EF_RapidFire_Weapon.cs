using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Gameplay
{
    public class EF_RapidFire_Weapon : EF_Raycast_Weapon 
    {
        #region Variables
        public float m_FireRate = 0.1f;
        private float m_LastFireTime = 0f;
        #endregion

        #region Main Methods
        public override void Start()
        {
            base.Start();
            m_LastFireTime = Time.time;
        }
        #endregion

        #region Custom Methods
        protected override void HandleWeaponFire()
        {
            if(Time.time > m_LastFireTime)
            {
                base.HandleWeaponFire();
                m_LastFireTime = Time.time + m_FireRate;
            }
        }
        #endregion
    }
}

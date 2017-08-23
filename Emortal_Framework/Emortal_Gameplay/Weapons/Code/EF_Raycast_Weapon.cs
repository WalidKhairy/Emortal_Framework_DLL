using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Gameplay
{
    public class EF_Raycast_Weapon : EF_Base_Weapon 
    {
        #region Variables
        public float m_AmmoPower = 30f;

        protected RaycastHit hit;
        #endregion


        #region Methods
        public override void Start()
        {
            base.Start();
        }

        protected override void HandleWeaponFire()
        {
            base.HandleWeaponFire();
        }

        protected override void CheckRaycast()
        {
            if(Physics.Raycast(m_MuzzlePosition, transform.forward, out hit, 500f))
            {
                hit.transform.SendMessage("Damage", m_AmmoPower, SendMessageOptions.DontRequireReceiver);
            }
        }
        #endregion
    }
}

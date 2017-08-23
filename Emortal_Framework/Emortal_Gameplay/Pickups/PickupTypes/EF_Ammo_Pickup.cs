using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Gameplay
{
    public class EF_Ammo_Pickup : EF_Pickup_Base 
    {
        #region Variables
        [Header("Ammo Properties")]
        public float m_AmmoValue = 10f;
        #endregion

        #region Methods
        protected override void ApplyPickup(GameObject other)
        {
            if(other.tag == m_TargetTag)
            {
                PickupData pickupData = new PickupData();
                pickupData.m_PickupObject = gameObject;
                pickupData.m_Value = m_AmmoValue;

                other.SendMessage("ApplyAmmo", pickupData, SendMessageOptions.DontRequireReceiver);

                base.ApplyPickup(other);
            }
        }
        #endregion
    }
}

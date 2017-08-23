using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Gameplay
{
    public class EF_Health_Pickup : EF_Pickup_Base 
    {
        #region Variables
        [Header("Health Properties")]
        public float m_HealthValue = 10f;
        #endregion

        #region Methods
        protected override void ApplyPickup(GameObject other)
        {
            PickupData pickupData = new PickupData();
            pickupData.m_PickupObject = gameObject;
            pickupData.m_Value = m_HealthValue;

            other.SendMessage("ApplyHealth", pickupData, SendMessageOptions.DontRequireReceiver);

            base.ApplyPickup(other);
        }
        #endregion
    }
}

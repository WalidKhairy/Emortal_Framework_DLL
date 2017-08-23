using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Emortal.Players
{
    public class EF_Player_Inventory : MonoBehaviour 
    {
        #region Variables
        //Need to store the collected Pickups 
        public UnityEvent OnPickupEvent = new UnityEvent();
        #endregion


        #region Methods
        //Invoke this method through a send message to apply Pickup data
        public void ApplyPickup()
        {
            if(OnPickupEvent != null)
            {
                OnPickupEvent.Invoke();
            }
        }
        #endregion
    }
}

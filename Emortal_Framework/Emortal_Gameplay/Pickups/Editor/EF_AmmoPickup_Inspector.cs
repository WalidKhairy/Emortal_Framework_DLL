using System.Collections;
using System.Collections.Generic;
using Emortal.Gameplay;
using UnityEditor;
using UnityEngine;

namespace Emortal.Gameplay
{
    [CustomEditor(typeof(EF_Ammo_Pickup))]
    public class EF_AmmoPickup_Inspector : EF_PickupBase_Inspector 
    {
        #region Variables
        private EF_Ammo_Pickup m_Target;
        #endregion

        #region Main Methods
        void OnEnable()
        {
            m_Target = (EF_Ammo_Pickup)target;
        }

        protected override void DrawHeader(string aTitle)
        {
            base.DrawHeader("Ammo Pickup");
        }

        protected override void DrawBody()
        {
            base.DrawBody();
        }
        #endregion
    }
}
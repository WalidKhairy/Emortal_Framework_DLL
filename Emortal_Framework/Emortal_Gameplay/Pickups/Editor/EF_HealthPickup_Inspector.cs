using System.Collections;
using System.Collections.Generic;
using Emortal.Gameplay;
using UnityEditor;
using UnityEngine;

namespace Emortal.Gameplay
{
    [CustomEditor(typeof(EF_Health_Pickup))]
    public class EF_HealthPickup_Inspector : EF_PickupBase_Inspector 
    {
        #region Variables
        private EF_Health_Pickup m_Target;
        #endregion

        #region Main Methods
        void OnEnable()
        {
            m_Target = (EF_Health_Pickup)target;
        }

        protected override void DrawHeader(string aTitle)
        {
            base.DrawHeader("Health Pickup");
        }

        protected override void DrawBody()
        {
            base.DrawBody();
        }
        #endregion
    }
}

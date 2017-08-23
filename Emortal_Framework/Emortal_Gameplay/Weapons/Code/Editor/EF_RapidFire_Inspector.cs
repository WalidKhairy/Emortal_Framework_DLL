using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Emortal.Gameplay
{
    [CustomEditor(typeof(EF_RapidFire_Weapon), true)]
    public class EF_RapidFire_Inspector : EF_Weapon_Inspector 
    {
        #region Variables
        #endregion

        #region Methods
        public override void OnEnable()
        {
            targetBase = (EF_RapidFire_Weapon)target;
            title = "Rapid Fire Weapon";
            base.OnEnable();
        }

        public override void OnDisable()
        {
            base.OnDisable();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }

        public override void OnSceneGUI()
        {
            base.OnSceneGUI();
        }
        #endregion
    }
}

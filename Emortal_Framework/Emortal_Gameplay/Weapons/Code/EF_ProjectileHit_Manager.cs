using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Gameplay
{
    public class EF_ProjectileHit_Manager : MonoBehaviour 
    {
        #region Variables
        [Header("Hit Effects")]
        public GameObject m_GroundHit;
        #endregion

        #region Main Methods
//        public void RegisterWeapon(EF_Base_Weapon aWeapon)
//        {
//            aWeapon.OnHit += HandleHit;
//        }
//
//        void HandleHit(object sender, HitArgs e)
//        {
//            if(e.hit.transform.tag.ToLower() == "ground" && m_GroundHit)
//            {
//                Instantiate(m_GroundHit, e.hit.point, Quaternion.LookRotation(e.hit.normal));
//            }
//        }
        #endregion
    }
}

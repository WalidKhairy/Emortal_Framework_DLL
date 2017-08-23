using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Emortal.Core;

namespace Emortal.Gameplay
{
    public class EF_Weapon_Menus 
    {
        [MenuItem("Emortal/Gameplay/Weapons/Create Single Fire Weapon")]
        public static void CreateSingleFireWeapon()
        {
            //A Gameobject needs to be selected to Do the setup.
            GameObject selectedGO = EF_Editor_Utils.GetSelectedObject("Please select a GameObject to set up as a Weapon");
            if(!selectedGO) 
                return;


            CreateWeapon(EF_WeaponType.Single, selectedGO);

        }


        [MenuItem("Emortal/Gameplay/Weapons/Create Rapid Fire Weapon")]
        public static void CreateRapidFireWeapon()
        {
            //A Gameobject needs to be selected to Do the setup.
            GameObject selectedGO = EF_Editor_Utils.GetSelectedObject("Please select a GameObject to set up as a Weapon");
            if(!selectedGO) 
                return;


            //We have a gameObject so lets get it set up as a Weapon
            CreateWeapon(EF_WeaponType.RapidFire, selectedGO);

        }

        [MenuItem("Emortal/Gameplay/Weapons/Create Projectile Fire Weapon")]
        public static void CreateProjectileFireWeapon()
        {
            //A Gameobject needs to be selected to Do the setup.
            GameObject selectedGO = EF_Editor_Utils.GetSelectedObject("Please select a GameObject to set up as a Weapon");
            if(!selectedGO) 
                return;


            //We have a gameObject so lets get it set up as a Weapon
            CreateWeapon(EF_WeaponType.Projectile, selectedGO);

        }


        #region Utility Methods
        private static void CreateWeapon(EF_WeaponType aType, GameObject aGo)
        {
            if(aGo)
            {
                //Make sure it isnt a Weapon already
                EF_Base_Weapon curWeapon = aGo.GetComponent<EF_Base_Weapon>();
                if(curWeapon)
                {
                    return;
                }

                //Lets create a new weapon
                switch(aType)
                {
                    case EF_WeaponType.Single:
                        aGo.AddComponent<EF_SingleFire_Weapon>();
                        break;

                    case EF_WeaponType.RapidFire:
                        aGo.AddComponent<EF_RapidFire_Weapon>();
                        break;

                    case EF_WeaponType.Projectile:
                        aGo.AddComponent<EF_ProjectileFire_Weapon>();
                        break;

                    default:
                        break;
                }

                //Set some presets
                AudioSource aSource = aGo.GetComponent<AudioSource>();
                if(aSource)
                {
                    aSource.playOnAwake = false;
                }
            }
        }
        #endregion
    }
}

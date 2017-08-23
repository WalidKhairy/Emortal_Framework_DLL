using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Emortal.Players
{
    public class EF_Player_Menus 
    {
        [MenuItem("Emortal/Players/Create New Player")]
        public static void CreatePlayer()
        {
            GameObject playerGO = new GameObject("Player");
            CapsuleCollider curCollider = playerGO.AddComponent<CapsuleCollider>();
            curCollider.height = 2f;
            curCollider.center = new Vector3(0f, 1f, 0f);

            //Create the Pill Dood
            GameObject pillGeo = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            pillGeo.transform.SetParent(playerGO.transform);
            pillGeo.transform.position = Vector3.up;

            playerGO.AddComponent<EF_Player>();
            Selection.activeGameObject = playerGO;

            //Set Rigidbody Settings
            Rigidbody rb = playerGO.GetComponent<Rigidbody>();
            if(rb)
            {
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            }

            //Set Audio Properties
            AudioSource aSource = playerGO.GetComponent<AudioSource>();
            if(aSource)
            {
                aSource.playOnAwake = false;
            }
        }
    }
}

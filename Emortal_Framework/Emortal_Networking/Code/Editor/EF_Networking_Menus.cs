using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using Emortal.Core;

namespace Emortal.Networking
{
    public class EF_Networking_Menus 
    {
        [MenuItem("Emortal/Networking/Create Network Manager")]
        public static void CreateNetworkManager()
        {
            GameObject managerGO = new GameObject("_NetworkManager");
            managerGO.AddComponent<NetworkManager>();
            managerGO.AddComponent<NetworkManagerHUD>();
            EF_Editor_Utils.DrawIcon(managerGO, 7);


            GameObject curSpawn = new GameObject("SpawnPoint_1");
            curSpawn.AddComponent<NetworkStartPosition>();
            curSpawn.transform.position = new Vector3(0, 0, 5f);
            curSpawn.transform.SetParent(managerGO.transform);
            EF_Editor_Utils.DrawIcon(curSpawn, 1);


            curSpawn = new GameObject("SpawnPoint_2");
            curSpawn.AddComponent<NetworkStartPosition>();
            curSpawn.transform.position = new Vector3(0, 0, -5f);
            curSpawn.transform.SetParent(managerGO.transform);
            EF_Editor_Utils.DrawIcon(curSpawn, 1);
        }
            
    }
        
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Emortal.Core;

namespace Emortal.Cameras
{
    public class EF_CameraManager : MonoBehaviour 
    {
        #region Variables
        [Header("Player Cameras")]
        public GameObject m_PCCamera;
        public GameObject m_VRCamera;
        #endregion

        #region Main Methods
    	// Use this for initialization
    	void Start () 
        {
            if(EF_Game_Manager.Instance)
            {
                if(EF_Game_Manager.Instance.m_IsVREnabled)
                {
                    m_VRCamera.SetActive(true);
                    m_PCCamera.SetActive(false);
                }
                else
                {
                    m_VRCamera.SetActive(false);
                    m_PCCamera.SetActive(true);
                }
            }
    	}
        #endregion
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.VR;
using Emortal.Players;

namespace Emortal.Core
{
    public class EF_Game_Manager : MonoBehaviour
    {
        #region Variables
        private static EF_Game_Manager m_instance;
        public EF_Player_Data m_playerData;

        public bool m_isPaused = false;
        public bool m_IsVREnabled = false;
        #endregion



        #region Methods
        public static EF_Game_Manager Instance
        {
            get
            {
                return EF_Game_Manager.m_instance;
            }
        }
            

        private void Awake()
        {
            if (m_instance == null)
            {
                m_instance = this;
            }
            else if (m_instance.GetInstanceID() != this.GetInstanceID())
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);
            CheckVRSettings();
        }

        public void LoadScene(int aLevelID)
        {
            if(!m_IsVREnabled)
            {
                EF_Loader_Manager.LoadScene(aLevelID);
            }
        }
        #endregion




        #region Utility Methods
        void CheckVRSettings()
        {
            m_IsVREnabled = VRDevice.isPresent && VRSettings.enabled;
            if (m_IsVREnabled)
            {
                //We have VR!  Set VR Settings Here
                Screen.SetResolution(1024, 768, false);
            }
            else
            {
                //We dont have VR.  Set PC settings here
                Screen.SetResolution(1920, 1080, false);
                VRSettings.enabled = false;
            }
        }

        //toggle pause
        public void PauseGame()
        {

            if (!m_isPaused)
            {
                AdjustTimeScale(0f);
                m_isPaused = true;
            }
            else
            {
                AdjustTimeScale(1f);
                m_isPaused = false;
            }
        }

        public void AdjustTimeScale(float m_timeScale)
        {
            Time.timeScale = m_timeScale;
        }

        public string getDateTime()
        {
            string dateAndTime = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            return dateAndTime;
        }

        public void QuitGame()
        {
            m_instance = null;
            Application.Quit();
        }
        #endregion
    }

}



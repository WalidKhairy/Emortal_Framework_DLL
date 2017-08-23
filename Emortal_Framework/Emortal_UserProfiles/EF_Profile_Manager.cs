using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Emortal.UserProfiles
{
    public class EF_Profile_Manager : MonoBehaviour 
    {
        #region Variables
        public static EF_Profile_Manager Instance;

        [Header("Current Data")]
        public EF_Profiles m_Profiles;

        private bool isLoggedIn = false;
        public bool IsLoggedIn{get{return isLoggedIn;}}

        private EF_Profile_Data currentUser;
        public EF_Profile_Data CurrentUser{get{return currentUser;}}
        #endregion




        #region Main Methods
        void Awake()
        {
            if(Instance == null)
            {
                DontDestroyOnLoad(this.gameObject);
                Instance = this;
            }
            else if(Instance.GetInstanceID() != this.GetInstanceID())
            {
                Destroy(gameObject);
            }

            //Load all profiles stored locally
            LoadProfiles();
        }

    	// Use this for initialization
    	void Start () 
        {
            isLoggedIn = false;
            currentUser = null;
    	}
    	
    	// Update is called once per frame
    	void Update () 
        {
    		
    	}
        #endregion




        #region Authentication Methods
        /// <summary>
        /// Basic Login Authentication using local storage profiles
        /// </summary>
        /// <returns><c>true</c>, if in profile was loged, <c>false</c> otherwise.</returns>
        /// <param name="username">Username.</param>
        public bool LogInProfile(string username)
        {
            bool success = false;
            if(m_Profiles.m_Profiles.Count > 0)
            {
                foreach(var profile in m_Profiles.m_Profiles)
                {
                    if(username == profile.username)
                    {
                        currentUser = profile;
                        success = true;
                    }
                }
            }

            return success;
        }


        /// <summary>
        /// Logs the out profile.
        /// </summary>
        /// <returns><c>true</c>, if out profile was loged, <c>false</c> otherwise.</returns>
        public void LogOutProfile()
        {
            currentUser = null;
            isLoggedIn = false;
        }


        /// <summary>
        /// Adds a profile to the current loacl profile data file
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="email">Email.</param>
        public void AddProfile(string username, string email)
        {
            //Make sure our Profiles Class isnt null
            if(m_Profiles == null)
            {
                m_Profiles = new EF_Profiles();
            }

            //Make sure our username and email is not empty
            if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(email))
            {
                //Create a new profile
                EF_Profile_Data curProfile = new EF_Profile_Data();
                curProfile.username = username;
                curProfile.email = email;
                curProfile.created = DateTime.Now;
                curProfile.lastLogIn = DateTime.Now;

                m_Profiles.m_Profiles.Add(curProfile);
                SaveProfiles();
                LoadProfiles();
            }
        }

        public void RemoveProfile()
        {
            
        }

        /// <summary>
        /// Loads a profile data file from the persisten data path Unity uses
        /// </summary>
        void LoadProfiles()
        {
            if(File.Exists(Application.persistentDataPath + "/user_profiles.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "user_profiles.dat", FileMode.Open);
                m_Profiles = (EF_Profiles)bf.Deserialize(file);
                file.Close();
            }
        }

        /// <summary>
        /// Saves a profile data file to the Unity persisten Data folder
        /// </summary>
        void SaveProfiles()
        {
            if(m_Profiles != null)
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Create(Application.persistentDataPath + "/user_profiles.dat");

                EF_Profiles curProfiles = m_Profiles;
                bf.Serialize(file, curProfiles);
                file.Close();
            }
        }
        #endregion
    }
}

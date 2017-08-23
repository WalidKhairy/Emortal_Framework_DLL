using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Emortal.UserProfiles
{
    public class EF_Profiles
    {
        #region Variables
        public List<EF_Profile_Data> m_Profiles = new List<EF_Profile_Data>();
        #endregion
    }


    [Serializable]
    public class EF_Profile_Data 
    {
        #region Variables
        public string username;
        public string email;
        public DateTime created;
        public DateTime lastLogIn;
        #endregion
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Emortal.Customization
{
    [Serializable]
    public class EF_Loadouts
    {
        #region Variables
        public List<EF_Loadouts> m_Loadouts = new List<EF_Loadouts>();
        #endregion
    }


    [Serializable]
    public class EF_Loadout_Data 
    {
        #region Variables
        public string owner;
        public DateTime created;

        public string loadoutTitle = "New Loadout";
        public List<EF_Customization_Category_Data> categories = new List<EF_Customization_Category_Data>();
        #endregion
    }


    [Serializable]
    public class EF_Customization_Category_Data
    {
        #region Variables
        #endregion
    }


    [Serializable]
    public class EF_Customization_Item_Data
    {
        #region Variables
        #endregion
    }
}

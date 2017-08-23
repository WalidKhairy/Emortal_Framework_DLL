using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Emortal.Gameplay
{
    public class ActionArgs : EventArgs
    {
        //Add data we need to send
        public string type;
    }

    [Serializable]
    public class EF_Action_Base : MonoBehaviour
    {
        #region Variables
        public bool m_IsUpdater = false;

        //Events
        public delegate void ActionCompleted(object sender, ActionArgs e);
        public event ActionCompleted OnActionCompleted;
        #endregion

        #region Main Methods
        public virtual void StartAction(){}
        public virtual void UpdateAction(){}

        protected void CompletedAction(ActionArgs e)
        {
            //Call the Completed event
            if(OnActionCompleted != null)
            {
                OnActionCompleted(this, e);
            }
        }
        #endregion
    }
}

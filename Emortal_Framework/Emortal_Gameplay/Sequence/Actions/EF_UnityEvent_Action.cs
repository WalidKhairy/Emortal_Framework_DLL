using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Emortal.Gameplay
{
    public class EF_UnityEvent_Action : EF_Action_Base 
    {
        #region Variables
        public UnityEvent unityEvent;
        #endregion

        #region Main Methods
        public override void StartAction()
        {
            base.StartAction();
            if(unityEvent != null)
            {
                unityEvent.Invoke();
            }

            ActionArgs args = new ActionArgs();
            args.type = "UnityEvent";
            CompletedAction(args);
        }
        #endregion
    }
}

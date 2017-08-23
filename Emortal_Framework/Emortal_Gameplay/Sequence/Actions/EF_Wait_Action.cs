using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Gameplay
{
    public class EF_Wait_Action : EF_Action_Base 
    {
        #region Variables
        public bool m_WaitForever = false;
        public float m_WaitTime = 2f;

        private float startTime;
        #endregion

        #region Main Methods
        public override void StartAction()
        {
            Debug.Log("Starting Wait Action");
            base.StartAction();
            startTime = Time.time;
        }

        public override void UpdateAction()
        {
            base.UpdateAction();

            if(!m_WaitForever)
            {
                if(Time.time >= startTime + m_WaitTime)
                {
                    ActionArgs args = new ActionArgs();
                    args.type = "Wait";
                    CompletedAction(args);
                }
            }
        }
        #endregion
    }
}

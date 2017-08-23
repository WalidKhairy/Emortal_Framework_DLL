using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Gameplay
{
    [System.Serializable]
    public class EF_Sequence 
    {
        #region Variables
        public List<EF_Action_Base> m_Actions = new List<EF_Action_Base>();

        private int currentActionIndex = 0;
        #endregion

        #region Main Methods
        public virtual void StartSequence()
        {
//            Debug.Log("Starting Sequence");
            currentActionIndex = 0;
            if(m_Actions.Count > 0 && m_Actions != null)
            {
                foreach(EF_Action_Base curAction in m_Actions)
                {
                    curAction.OnActionCompleted += SetNextAction;
                }

                m_Actions[currentActionIndex].StartAction();
            }
        }

        public virtual void UpdateSequence()
        {
//            Debug.Log("Updating Sequence");
            if(currentActionIndex < m_Actions.Count)
            {
                if(m_Actions[currentActionIndex] != null && m_Actions[currentActionIndex].m_IsUpdater)
                {
                    m_Actions[currentActionIndex].UpdateAction();
                }
            }
        }

        public void SetNextAction(object sender, ActionArgs e)
        {
            Debug.Log(e.type + " :Just completed");
            currentActionIndex++;

            if(currentActionIndex < m_Actions.Count)
            {
                m_Actions[currentActionIndex].StartAction();
            }
        }
        #endregion
    }
}

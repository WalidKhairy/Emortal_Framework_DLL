using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Gameplay
{
    public class EF_Level_Manager : MonoBehaviour 
    {
        #region Variables
        private static EF_Level_Manager m_Instance;
        public EF_Level_Manager Instance
        {
            get
            {
                return m_Instance;
            }
        }

        [SerializeField]
        private EF_Sequence levelSequence = new EF_Sequence();
        #endregion


        #region Main Methods
    	// Use this for initialization
        void Awake()
        {
            if(m_Instance == null)
            {
                m_Instance = this;
            }
            else if(m_Instance.GetInstanceID() != this.GetInstanceID())
            {
                Destroy(this.gameObject);
            }    
        }

    	void Start () 
        {
            if(levelSequence != null)
            {
                levelSequence.StartSequence();
            }
    	}
    	
    	// Update is called once per frame
    	void Update () 
        {
            if(levelSequence != null)
            {
                levelSequence.UpdateSequence();
            }
    	}
        #endregion


        #region Util Methods
        public void SetNextAction()
        {
            if(levelSequence != null)
            {
                ActionArgs args = new ActionArgs();
                args.type = "LevelManager Action";
                levelSequence.SetNextAction(this, args);
            }
        }
        #endregion
    }
}

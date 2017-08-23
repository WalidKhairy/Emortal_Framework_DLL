using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Emortal.Gameplay
{
    [RequireComponent(typeof(BoxCollider))]
    public class EF_Trigger_Base : MonoBehaviour 
    {
        #region Variables
        public UnityEvent OnEnter = new UnityEvent();
        public UnityEvent OnExit = new UnityEvent();

        protected BoxCollider boxCollider;
        #endregion

        #region Methods
    	// Use this for initialization
    	void Start () 
        {
            boxCollider = GetComponent<BoxCollider>();
            boxCollider.isTrigger = true;
    	}
        #endregion

        #region Trigger Methods
        void OnTriggerEnter(Collider other)
        {
            HandleEnter();
        }

        protected virtual void HandleEnter()
        {
            if(OnEnter != null)
            {
                OnEnter.Invoke();
            }
        }

        void OnTriggerExit(Collider other)
        {
            HandleExit();
        }

        protected virtual void HandleExit()
        {
            if(OnExit != null)
            {
                OnExit.Invoke();    
            }
        }
        #endregion
    }
}

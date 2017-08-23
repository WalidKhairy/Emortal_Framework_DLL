using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Emortal.Destruction
{
    public class ActivateObjectOnCollision : MonoBehaviour 
    {
        #region Variables
        [Header("Main Properties")]
        public float activationForce = 20;

        [Header("Event")]
        public UnityEvent OnCollisionEvent = new UnityEvent();

        private Rigidbody rb;
        private float velocity;
        bool isReady;
        #endregion

        #region Methods
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            if(rb == null || OnCollisionEvent == null)
            {
                isReady = false;
            }
        }

        void OnCollisionEnter(Collision col)
        {
            HandleCollisionEvent(col);
        }

        void OnCollisionExit(Collision col)
        {
            HandleCollisionEvent(col);
        }

        void HandleCollisionEvent(Collision col)
        {
            if(isReady)
            {
                if(!rb.isKinematic && !rb.IsSleeping())
                {
                    var v = Mathf.Abs(rb.velocity.sqrMagnitude);

                    if((v - velocity) > activationForce)
                    {
                        OnCollisionEvent.Invoke();
                    }

                    velocity = v;
                }
            }
        }
        #endregion
    }
}

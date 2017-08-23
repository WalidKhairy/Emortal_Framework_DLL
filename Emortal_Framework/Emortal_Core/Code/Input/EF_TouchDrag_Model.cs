using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Emortal.Core
{
    public class EF_TouchDrag_Model : MonoBehaviour 
    {
        #region Variables
        public RectTransform m_TouchDragPanel;
        public bool m_AllowDragging = true;
        public float m_TouchSensitivty = 200f;
        public float m_slowdownSpeed = 2f;

        private Vector2 mouseDelta;
        private float curYVal = 0f;
        #endregion



        #region Methods
    	// Use this for initialization
    	void Start () 
        {
            curYVal = transform.eulerAngles.y;
    	}
    	
    	// Update is called once per frame
    	void Update () 
        {
            CheckTouchDragRect();

            //Get our wanted drag angle from the delta
            if(m_AllowDragging)
            {
                if(Input.GetMouseButton(0))
                {
                    mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                }
                else
                {
                    mouseDelta = Vector2.Lerp(mouseDelta, Vector2.zero, Time.deltaTime * m_slowdownSpeed);
                }
            }
            else
            {
                mouseDelta = Vector2.Lerp(mouseDelta, Vector2.zero, Time.deltaTime * m_slowdownSpeed);
            }

            //Apply the Rotation
            curYVal += mouseDelta.x * m_TouchSensitivty * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, -curYVal, 0f);
    	}

        void CheckTouchDragRect()
        {
            if(m_TouchDragPanel && Input.GetMouseButtonDown(0))
            {
                if(RectTransformUtility.RectangleContainsScreenPoint(m_TouchDragPanel, Input.mousePosition))
                {
                    m_AllowDragging = true;
                }
                else
                {
                    m_AllowDragging = false;
                }
            }
        }
        #endregion
    }
}

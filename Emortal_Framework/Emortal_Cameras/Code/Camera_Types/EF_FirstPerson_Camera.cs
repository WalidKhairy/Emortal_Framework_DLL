using UnityEngine;
using Emortal.Core;


namespace Emortal.Cameras
{
    public class EF_FirstPerson_Camera : EF_Base_Camera 
    {
        #region Varaibles
        [Header("FPS Properties")]
        public Vector2 m_MinMaxLookAngle = new Vector2(-30f, 50f);
        #endregion

        #region Methods
        protected override void UpdateRotation()
        {
            if(EF_InputGlobal.Instance != null)
            {
                transform.Rotate(new Vector3(-EF_InputGlobal.Instance.XAxis, 0f, 0f));
            }
        }
        #endregion
    }
}

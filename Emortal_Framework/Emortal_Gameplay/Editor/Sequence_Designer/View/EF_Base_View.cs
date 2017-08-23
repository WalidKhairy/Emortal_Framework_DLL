using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Emortal.Gameplay
{
    [System.Serializable]
    public class EF_Base_View 
    {
        #region Variables
        protected bool isInView = false;
        protected Event curEvent;

        public Rect viewRect;
        #endregion

        #region Constructor
        public EF_Base_View(){}
        #endregion


        #region Methods
        public virtual void DrawView()
        {
            viewRect = new Rect(0, 0f, 10000f, 10000f);
            GUILayout.BeginArea(viewRect);
            DrawEditor();
            GUILayout.EndArea();

        }

        protected virtual void DrawEditor(){}
        #endregion
    }
}

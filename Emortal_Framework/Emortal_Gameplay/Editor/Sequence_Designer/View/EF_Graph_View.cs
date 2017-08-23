using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Emortal.Gameplay
{
    public class EF_Graph_View : EF_Base_View 
    {
        #region Variables
        float gridSpacing;
        int widthDivs;
        int heightDivs;
        #endregion

        #region Constructor
        public EF_Graph_View() : base(){}
        #endregion

        #region Methods
        protected override void DrawEditor()
        {
            EF_View_Utils.DrawGraphGrid(viewRect, 100f, 0.05f, Color.white);
            EF_View_Utils.DrawGraphGrid(viewRect, 20f, 0.05f, Color.white);
        }
        #endregion
    }
}

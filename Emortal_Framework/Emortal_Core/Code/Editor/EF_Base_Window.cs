using UnityEditor;
using UnityEngine;

namespace Emortal.Core
{
    public class EF_Base_Window : EditorWindow 
    {
        #region Variables
        protected GameObject[] m_SelectedObjects = new GameObject[0];
        #endregion

        #region Methods
        protected virtual void GetSelected()
        {
            m_SelectedObjects = Selection.gameObjects;
        }
        #endregion
    }
}

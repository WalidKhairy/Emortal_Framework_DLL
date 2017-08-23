using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Emortal.Customization
{
    #if UNITY_EDITOR
    [CanEditMultipleObjects]
    #endif
    public class EF_Customizer_Item : MonoBehaviour
    {
        #region Variables
        public Sprite m_Icon;
        public Material m_ItemMaterial;
        public int itemID;
        public EF_Customizer_Category m_Category;
        #endregion

        #region Methods
        public void InitItem()
        {
            Renderer renderer = gameObject.GetComponent<Renderer>();

            if(renderer)
            {
                m_ItemMaterial = renderer.sharedMaterial;
            }
            gameObject.SetActive(false);

        }

        public void ResetItem()
        {
            gameObject.SetActive(false);
        }

        public void UpdateColor(Color aColor)
        {
            Debug.Log("Updating Color on: " + name);
        }
        #endregion
    }
}

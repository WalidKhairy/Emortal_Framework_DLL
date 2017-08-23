using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Emortal.Customization
{
    #if UNITY_EDITOR
    [CanEditMultipleObjects]
    #endif
    public class EF_Customizer_Category : MonoBehaviour
    {
        #region Variables
        public List<EF_Customizer_Category> m_SubCategories = new List<EF_Customizer_Category>();
        public List<EF_Customizer_Item> m_Items = new List<EF_Customizer_Item>();

        public Sprite m_Icon;
        public bool m_IsActive;
        public int m_ID;
        public bool m_isActive;

        private EF_Customizer_Item currentSelectedItem;
        #endregion

        #region Methods
        public void FindItems(string itemSuffix, string categorySuffix)
        {
            //Look into the Categories Hirearchy to see if it contains any Items
            int childCount = transform.childCount;
            for(int i = 0; i < childCount; i++)
            {
                Transform curChild = transform.GetChild(i);
                if(curChild.name.IndexOf(itemSuffix) > 0)
                {
                    EF_Customizer_Item curItem = curChild.gameObject.AddComponent<EF_Customizer_Item>();
                    m_Items.Add(curItem);
                    curItem.InitItem();
                    curItem.itemID = i;
                    curItem.m_Category = this;
                }

                if(curChild.name.IndexOf(categorySuffix) > 0)
                {
                    EF_Customizer_Category curCategory = curChild.gameObject.AddComponent<EF_Customizer_Category>();
                    m_SubCategories.Add(curCategory);
                    curCategory.FindItems(itemSuffix, categorySuffix);
                }
            }
        }
            

        public void UpdateItems(int itemID)
        {
//            Debug.Log("Updating Item: " + itemID.ToString());

            if(itemID < m_Items.Count)
            {
                for(int i = 0; i < m_Items.Count; i++)
                {
                    m_Items[i].gameObject.SetActive(false);
                }

                m_Items[itemID].gameObject.SetActive(true);
            }
        }

        public void ResetItems()
        {
            foreach(var subCategory in m_SubCategories)
            {
                subCategory.ResetItems();
            }

            foreach(var item in m_Items)
            {
                item.ResetItem();
            }
        }

        public void CleanData()
        {
            if(m_SubCategories.Count > 0)
            {
                foreach(var category in m_SubCategories)
                {
                    category.CleanData();
                    DestroyImmediate(category);
                }
            }

            if(m_Items.Count > 0)
            {
                foreach(var item in m_Items)
                {
                    DestroyImmediate(item);
                }
            }

            DestroyImmediate(this);
        }

        public void UpdateItemColor(Color aColor)
        {
            if(currentSelectedItem)
            {
                currentSelectedItem.UpdateColor(aColor);
            }
        }
        #endregion
    }
}

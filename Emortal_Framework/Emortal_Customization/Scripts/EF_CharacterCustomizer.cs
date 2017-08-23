using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emortal.Customization
{
    public class EF_CharacterCustomizer : MonoBehaviour 
    {
        #region Variables
        [Header("Configuration Properties")]
//        public GameObject m_BaseBody;
        public string m_BodyGrpName = "Body_GRP";
        public string m_HeadGrpName = "Head_GRP";
        public string m_CategorySuffix = "GRP";
        public string m_ItemSuffix = "PART";


        [Header("Categories")]
        public List<EF_Customizer_Category> m_Categories = new List<EF_Customizer_Category>();

        [HideInInspector]
        public EF_Face_Manager faceManager;
        #endregion






        #region Main Methods
    	// Use this for initialization
    	void Start () 
        {
            if(m_Categories.Count == 0)
            {
                InitializeCustomization();
            }
    	}
        #endregion






        #region Utility Methods
        public void InitializeCustomization()
        {
            //Clear out Current Data
            m_Categories.Clear();

            //Start the Set up process
            Transform modelTransform = transform;
            int childCount = modelTransform.childCount;

            for(int i = 0; i < childCount; i++)
            {
                Transform curChild = modelTransform.GetChild(i);
                if(curChild.name.IndexOf(m_CategorySuffix) > 0 && curChild.name != m_BodyGrpName)
                {
                    CreateCategory(curChild.gameObject);

                    //Assign the Head Manager Script
                    if(curChild.name == m_HeadGrpName)
                    {
                        faceManager = curChild.gameObject.AddComponent<EF_Face_Manager>();
                        faceManager.InitFaceManager();
                    }
                }
            }
        }

        void CreateCategory(GameObject aGO)
        {
            if(aGO)
            {
                //assign the Category Component to the gameobject
                EF_Customizer_Category curCategory = aGO.AddComponent<EF_Customizer_Category>();
                m_Categories.Add(curCategory);
                curCategory.FindItems(m_ItemSuffix, m_CategorySuffix);
            }
        }

        public void CleanData()
        {
            if(faceManager)
            {
                DestroyImmediate(faceManager);
            }

            if(m_Categories.Count > 0)
            {
                foreach(var category in m_Categories)
                {
                    if(category != null)
                    {
                        category.CleanData();
                    }
                }
            }

            m_Categories.Clear();
        }

        public void ResetItems()
        {
            foreach(var category in m_Categories)
            {
                category.ResetItems();
            }
        }
        #endregion



    }
        
}

using System;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Emortal.Core
{
    public class EF_Grid_System : MonoBehaviour
    {
        
        #region Variables
        public int m_gridRows;
        public int m_gridCollumns;
        public Material m_validMaterial;
        public Material m_occupiedMaterial;
        public float m_cellWidth = 1;
        public float m_cellHeight = 1;
        public Color m_gridColor;
        public Color m_hoverColor;
        public GameObject m_cell;
        public bool m_useXYcoords = false;
        public bool m_drawAllTiles;
        public Vector3 m_hoverPosition;
        public Dictionary<string, cellData> m_cellDirectory;
        
        public int count = 0;
        #endregion



        #region Methods
        public EF_Grid_System()
        {
            m_gridCollumns = 5;
            m_gridRows = 5;
           m_cellDirectory = new Dictionary<string, cellData>();
            
        }

        private void OnDrawGizmosSelected()
        {
            var m_gridHeight = m_gridRows * m_cellWidth;
            var m_gridWidth = m_gridCollumns * m_cellHeight;
            var m_gridPosition = gameObject.transform.position;
            Gizmos.color = m_gridColor;
            if (m_useXYcoords)
            {
                Gizmos.DrawLine(m_gridPosition, m_gridPosition + new Vector3(m_gridWidth, 0, 0));
                Gizmos.DrawLine(m_gridPosition, m_gridPosition + new Vector3(0, m_gridHeight, 0));
                Gizmos.DrawLine(m_gridPosition + new Vector3(m_gridWidth, 0, 0), m_gridPosition + new Vector3(m_gridWidth, m_gridHeight, 0));
                Gizmos.DrawLine(m_gridPosition + new Vector3(0, m_gridHeight, 0), m_gridPosition + new Vector3(m_gridWidth, m_gridHeight, 0));
                Gizmos.color = m_gridColor;
                for (float i = 1; i < m_gridRows + 4; i++)
                {
                    Gizmos.DrawLine(m_gridPosition + new Vector3(i * m_cellWidth, 0, 0), m_gridPosition + new Vector3(i * m_cellWidth, m_gridHeight, 0));

                }

                for (float i = 1; i < m_gridCollumns; i++)
                {
                    Gizmos.DrawLine(m_gridPosition + new Vector3(0, i * m_cellHeight, 0), m_gridPosition + new Vector3(m_gridWidth, i * m_cellHeight, 0));
                }
                Gizmos.color = m_hoverColor;
                Gizmos.DrawWireSphere(m_hoverPosition, m_cellWidth + 1);
            }
            else
            {
                //draw border
                Gizmos.DrawLine(m_gridPosition, m_gridPosition + new Vector3(m_gridWidth, 0, 0));//top
                Gizmos.DrawLine(m_gridPosition, m_gridPosition + new Vector3(0, 0, m_gridHeight));//right
                Gizmos.DrawLine(m_gridPosition + new Vector3(m_gridWidth, 0, 0), m_gridPosition + new Vector3(m_gridWidth, 0, m_gridHeight));//left
                Gizmos.DrawLine(m_gridPosition + new Vector3(0, 0, m_gridHeight), m_gridPosition + new Vector3(m_gridWidth, 0, m_gridHeight));//bottom
                Gizmos.color = m_gridColor;
                //draw vertical lines
                for (int col = 1; col < m_gridCollumns + 1; col++)
                {
                    Gizmos.DrawLine(m_gridPosition + new Vector3(col * m_cellWidth, 0, 0), m_gridPosition + new Vector3(col * m_cellWidth, 0, m_gridHeight));
                }
                for (float row = 1; row < m_gridRows; row++)
                {
                    Gizmos.DrawLine(m_gridPosition + new Vector3(0, 0, row * m_cellHeight), m_gridPosition + new Vector3(m_gridWidth, 0, row * m_cellHeight));
                }
                Gizmos.color = m_hoverColor;
                Gizmos.DrawWireCube(m_hoverPosition, new Vector3(m_cellWidth, 0, m_cellHeight) * 1.1f);
            }
        }
    


        public void AddToDirectory(string tileName, cellData cellData)
        {
            count++;
            Debug.Log(count);
            if (!m_cellDirectory.ContainsKey(tileName))
            {
                m_cellDirectory.Add(tileName, cellData);
                
            }
        }
        #endregion
    }
}


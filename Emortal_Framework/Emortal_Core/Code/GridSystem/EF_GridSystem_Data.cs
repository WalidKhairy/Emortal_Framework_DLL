using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using Emortal.Core;


namespace Emortal.Core
{
 
     #region Structs
     [Serializable]
     public struct EF_MouseInput
     {
        public Vector2 mousePos;
        public bool leftClickHold;
        public bool leftClick;
        public bool rightClick;
        public bool rightClickHold;
        public Vector2 mouseDelta;
    };


    [Serializable]
    public struct EF_GridData
    {
        public float m_cellWidth;
        public float m_cellHeight;
        public int m_gridRows;
        public int m_gridCollumns;
        public bool m_drawAllTiles;
        public bool m_useXYCoords;
        public Material m_validMaterial;
        public Material m_occupiedMaterial;

        public EF_GridData(float cellWidth, float cellHeight, int gridRows, int gridCollumns, bool drawAllTiles, bool useXYCoords, Material validMaterial, Material occupiedMaterial)
        {
            m_cellWidth = cellWidth;
            m_cellHeight = cellHeight;
            m_gridRows = gridRows;
            m_gridCollumns = gridCollumns;
            m_drawAllTiles = drawAllTiles;
            m_useXYCoords = useXYCoords;
            m_validMaterial = validMaterial;
            m_occupiedMaterial = occupiedMaterial;
        }
    };


    [Serializable]
    public struct EF_CellData
    {
        public GameObject m_tile;
        public int m_row;
        public int m_collumn;
        public bool m_isOccupied;

        public EF_CellData(GameObject tile, int row, int collumn, bool isOccupied)
        {
            m_tile = tile;
            m_row = row;
            m_collumn = collumn;
            m_isOccupied = isOccupied;
        }
    };
        #endregion


}





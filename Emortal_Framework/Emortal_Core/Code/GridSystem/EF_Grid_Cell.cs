using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Emortal.Core
{
    public class EF_Grid_Cell: MonoBehaviour
    { 

        public EF_Grid_System m_grid;
        public Material m_material;
        public GameObject m_occupantUnit; 
        public cellData m_cellData;

        void OnEnable()
        {
            m_occupantUnit = GameObject.CreatePrimitive(PrimitiveType.Cube);//cube by default
        }

        public EF_Grid_Cell(EF_Grid_System grid, int collumn, int row) 
        {

            m_grid = grid;
            var m_cellWidth = m_grid.m_cellWidth;
            var m_cellHeight = m_grid.m_cellWidth;
            var tile = GameObject.CreatePrimitive(PrimitiveType.Cube);

            var m_cellScript = tile.AddComponent<EF_Grid_Cell>();
            tile.transform.parent = grid.transform;
            tile.transform.position = grid.transform.position + new Vector3(collumn * m_cellHeight - m_cellHeight / 2, 0, row * m_cellWidth - m_cellWidth / 2);
            m_cellScript.transform.SetParent(tile.transform);
            var m_position = new Vector3(tile.transform.localPosition.x / m_cellWidth, m_grid.transform.localPosition.y, tile.transform.localPosition.z / m_cellHeight);
            m_position = new Vector3((int)Math.Round(m_position.x, 5, MidpointRounding.ToEven), 0, (int)Math.Round(m_position.z, 5, MidpointRounding.ToEven));
            var m_collumn = (int)m_position.x;
            var m_row = (int)m_position.z;
            tile.name = string.Format("Cell_{0}_{1}", collumn, row);
            tile.GetComponent<Renderer>().sharedMaterial.CopyPropertiesFromMaterial(grid.m_occupiedMaterial);

        }

        public void SetOccupant(GameObject occupant)
        {
            m_occupantUnit = occupant;
            occupant.transform.position = this.transform.position;
            
        }
    }

    


    public struct cellData
    {
        GameObject m_tileV;
        int m_rowV;
        int m_collumnV;
        string m_tileNameV;
        bool m_isOccupiedV;

        public cellData(GameObject tile, int row, int collumn, string tileName, bool isOccupied)
        {
            m_tileV = tile;
            m_rowV = row;
            m_collumnV = collumn;
            m_tileNameV = tileName;
            m_isOccupiedV = isOccupied;

        }
    }
}
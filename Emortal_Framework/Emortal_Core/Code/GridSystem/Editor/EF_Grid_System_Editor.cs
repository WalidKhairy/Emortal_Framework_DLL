using UnityEngine;

namespace Emortal.Core
{
    using System;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;

    
    [CustomEditor(typeof(EF_Grid_System))]
    public class EF_Grid_System_Editor : Editor
    {
        
        public float m_cellWidth = 4;
        public float m_cellHeight = 5;
        public Color m_hoverColor;
        public GameObject m_cell;
        public bool m_useXYcoords = false;
        public bool m_drawAll;
        public GameObject defaultUnitObject = GameObject.CreatePrimitive(PrimitiveType.Cube);


        public Vector3 m_hoverPosition;
        public Dictionary<string, cellData> m_cellDirectory;

        private Vector3 mouseHitPos;
        public EF_Grid_System m_Grid;
        public int dictCount;

        private RaycastHit m_CurHit;
        private GameObject m_CurrentGO;
        //public int m_gridRows;

        SerializedProperty m_gridRows;
        SerializedProperty m_gridCollumns;
        SerializedProperty m_occupiedMaterial;
        SerializedProperty m_validMaterial;
        SerializedProperty m_gridColor;
        //SerializedProperty m_drawAllTiles;
       

        public void Update()
        {
            Debug.Log(m_Grid.m_cellDirectory.Count);
        }

        private void OnEnable()
        {

            m_Grid = (EF_Grid_System)target;
            SceneView.onSceneGUIDelegate += UpdateGrid;
            m_gridRows = serializedObject.FindProperty("m_gridRows");
            m_gridCollumns = serializedObject.FindProperty("m_gridCollumns");
            m_gridColor = serializedObject.FindProperty("m_gridColor");
         
            //dictCount = m_Target.m_cellDirectory.Count;
            //m_cell = serializedObject.FindProperty("m_cell");
            m_occupiedMaterial = serializedObject.FindProperty("m_occupiedMaterial");
            m_validMaterial = serializedObject.FindProperty("m_validMaterial");
            //m_drawAllTiles = serializedObject.FindProperty("m_drawAllTiles");
            Tools.current = Tool.View;
            Tools.viewTool = ViewTool.FPS;
            
            
        }

        public void OnDisable()
        {
            SceneView.onSceneGUIDelegate -= UpdateGrid;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.BeginVertical(GUI.skin.box, GUILayout.ExpandWidth(true));
            EditorGUILayout.PropertyField(m_occupiedMaterial, new GUIContent("Occupied material: "));
           // m_Grid.m_validMaterial = (Material)EditorGUILayout.PropertyField(m_validMaterial, new GUIContent("Unoccupied material: "));
            m_Grid.m_drawAllTiles = EditorGUILayout.Toggle("Draw all tiles in grid?", m_Grid.m_drawAllTiles);
            m_Grid.m_gridRows=  EditorGUILayout.IntField("Grid Rows: " , m_Grid.m_gridRows);
            m_Grid.m_gridCollumns = EditorGUILayout.IntField("Grid Collumns: ", m_Grid.m_gridCollumns);
            m_Grid.m_gridColor = EditorGUILayout.ColorField("Grid Color: ", m_Grid.m_gridColor);
            m_Grid.m_cellWidth = EditorGUILayout.FloatField("Cell width: ", m_Grid.m_cellWidth);
            m_Grid.m_cellHeight = EditorGUILayout.FloatField("Cell height: ", m_Grid.m_cellHeight);
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();
            if (GUILayout.Button("Open Grid Window", GUILayout.ExpandWidth(true), GUILayout.Height(75)))
            {
               // EF_Grid_System_Window window = (EF_Grid_System_Window)EditorWindow.GetWindow(typeof(EF_Grid_System_Window));
                //window.Init();
            }

            SceneView.RepaintAll();
        }


        void UpdateGrid(SceneView sceneview)
        {
            Event e = Event.current;
        }


        private void OnSceneGUI()
        {
            if (m_Grid.m_drawAllTiles)
            {
                DrawAll();
            }

            DrawCircleHover();
            if (UpdateHitPosition())
            {
                SceneView.RepaintAll();
            }
            UpdateMousePosition();
            Event current = Event.current;
            if (isMouseHover())
            {

                if (current.type == EventType.MouseDown || current.type == EventType.MouseDrag)
                {
                    if (current.button == 1)
                    {
                        Erase();
              
                        current.Use();
                    }
                    else if (current.button == 0)
                    {
                        Draw();
                        current.Use();
                    }
                }
            }
            Handles.BeginGUI();
            GUI.Label(new Rect(10, Screen.height - 90, 100, 100), "Left click: Erase");
            GUI.Label(new Rect(10, Screen.height - 105, 100, 100), "Right click: Draw");
            Handles.EndGUI();
        }


        
        private void DrawAll()
        {
            var m_Target = (EF_Grid_System)target;
            //var m_cellPosition = GetCellPosition();
            //check if cell exists 

                for (int collumns = 1; collumns < m_Target.m_gridCollumns + 1; collumns++)
                {
                     for (int rows = 1; rows < m_Target.m_gridRows + 1; rows++)
                     {
                        var cube = GameObject.Find(string.Format("Cell_{0}_{1}", collumns, rows));
                       
                        if (cube == null)
                            {
                                EF_Grid_Cell m_newCell = new EF_Grid_Cell(m_Target, collumns, rows);
                                m_newCell.m_occupantUnit.GetComponent<Renderer>().sharedMaterial.CopyPropertiesFromMaterial(m_Target.m_validMaterial);


                    }
                                  
                }
            }

        }



        private void Draw()
        {
            var m_grid = (EF_Grid_System)target;
            var m_cellPosition = GetCellPosition();
            //check if cell exists 
            var unit = GameObject.Find(string.Format("Cell_{0}_{1}", m_cellPosition.x+ 1, m_cellPosition.z + 1));
            if (unit != null && unit.transform.parent != m_grid.transform)
            {
                return;
            }
            if (unit == null)
            {
                unit = defaultUnitObject;
            }
            var m_cellLocalPosition = new Vector3((m_cellPosition.x * m_grid.m_cellWidth) + (m_grid.m_cellWidth / 2), 0, (m_cellPosition.z * m_grid.m_cellHeight) + (m_grid.m_cellHeight / 2));
            unit.transform.position = m_grid.transform.position + m_cellLocalPosition;
            unit.transform.localScale = new Vector3(m_grid.m_cellWidth, 0, m_grid.m_cellHeight);
            unit.transform.parent = m_grid.transform;
            unit.name = string.Format("Cell_{0}_{1}", m_cellPosition.x + 1, m_cellPosition.z + 1);
            
        }

        private void Erase()
        {
            var m_grid = (EF_Grid_System)target;
            var tilePos = GetCellPosition();
            var cube = GameObject.Find(string.Format("Cell_{0}_{1}", tilePos.x, tilePos.z));
            if (cube != null && cube.transform.parent == m_grid.transform)
            {
                DestroyImmediate(cube);
            }
        }

        //gets cell position based on where the mouse is hovering
        private Vector3 GetCellPosition()
        {
            var m_grid = (EF_Grid_System)target;
            var m_position = new Vector3(mouseHitPos.x / m_grid.m_cellWidth, m_grid.transform.position.y, mouseHitPos.z / m_grid.m_cellHeight);
            m_position = new Vector3((int)Math.Round(m_position.x, 5, MidpointRounding.ToEven), 0, (int)Math.Round(m_position.z, 5, MidpointRounding.ToEven));
            var m_collumn = (int)m_position.x;
            var m_row = (int)m_position.z;
            if (m_row < 0)
            {
                m_row = 0;
            }
            if (m_row > m_grid.m_gridRows - 1)
            {
                m_row = m_grid.m_gridRows - 1;
            }
            if (m_collumn < 0)
            {
                m_collumn = 0;
            }
            if (m_collumn > m_grid.m_gridCollumns - 1)
            {
                m_collumn = m_grid.m_gridCollumns - 1;
            }
            return new Vector3(m_collumn, 0, m_row);
        }

        private bool isMouseHover()
        {
            var m_grid = (EF_Grid_System)target;
            return mouseHitPos.x > 0 && mouseHitPos.x < (m_grid.m_gridCollumns * m_grid.m_cellWidth) &&
                   mouseHitPos.z > 0 && mouseHitPos.z < (m_grid.m_gridRows * m_grid.m_cellHeight);
        }

        private void UpdateMousePosition()
        {
            var m_gridPosition = (EF_Grid_System)target;
            var m_cellPosition = GetCellPosition();
            var m_position = new Vector3(m_cellPosition.x * m_gridPosition.m_cellWidth, 0, m_cellPosition.z * m_gridPosition.m_cellHeight);
            m_gridPosition.m_hoverPosition = m_gridPosition.transform.position + new Vector3(m_position.x + (m_gridPosition.m_cellWidth / 2), 0, m_position.z + (m_gridPosition.m_cellHeight / 2));
        }
        
        public void OnColliderEnter(Collider collider)
        {
            m_Grid.GetComponent<Renderer>().sharedMaterial.CopyPropertiesFromMaterial(m_Grid.m_occupiedMaterial);
            Debug.Log("triger");
            //var m = m_tile.GetComponent<Collider>();

        }
        private void DrawCircleHover()
        {
            {
                var m_grid = (EF_Grid_System)target;
                //Update the Scene View
                Event e = Event.current;

                //Get the mouse Position and transform it to world space
                //then use the world space ray to see if we hit something in
                //the scene view.
                Vector2 mousePos = e.mousePosition;
                Ray worldRay = HandleUtility.GUIPointToWorldRay(mousePos);
                if (!Physics.Raycast(worldRay, out m_CurHit, float.MaxValue))
                {
                    m_CurrentGO = null;
                    return;
                }
                m_CurrentGO = m_CurHit.transform.gameObject;
                m_CurrentGO.GetComponent<Renderer>().sharedMaterial.CopyPropertiesFromMaterial(m_Grid.m_occupiedMaterial);

                //Draw a circle around the hit position
                Handles.color = new Color(1f, 0f, 0f, 0.25f);
                Handles.DrawSolidDisc(m_CurHit.point, m_CurHit.normal, m_grid.m_cellWidth/3);
                Handles.color = new Color(1f, 0f, 0f, 1f);
                Handles.DrawWireDisc(m_CurHit.point, m_CurHit.normal, m_grid.m_cellWidth/2);

                //Draw  3D-2D GUI
                Handles.BeginGUI();

                GUIStyle aStyle = new GUIStyle();
                aStyle.fontSize = 18;
                aStyle.normal.textColor = Color.blue;
                Handles.Label(m_CurHit.point + Vector3.up, "Hitting: " + m_CurrentGO.name, aStyle);

         

                Handles.EndGUI();
                HandleUtility.Repaint();


                //Draw 2D GUI
                Handles.BeginGUI();
                GUILayout.BeginArea(new Rect(Screen.width - 220, Screen.height - 120, 200, 100));

                GUILayout.Label("Hitting: " + m_CurrentGO.name, aStyle);

                GUILayout.EndArea();
                Handles.EndGUI();


            }
        }

        private bool UpdateHitPosition()
        {
            var m_grid = (EF_Grid_System)target;
            var m_plane = new Plane(m_grid.transform.TransformDirection(Vector3.down), m_grid.transform.position);
            var m_ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            var m_hit = new Vector3();
            float dist;
            if (m_plane.Raycast(m_ray, out dist))
            {
                m_hit = m_ray.origin + (m_ray.direction.normalized * dist);
            }
            var value = m_grid.transform.InverseTransformPoint(m_hit);
            if (value != mouseHitPos)
            {
                mouseHitPos = value;
                return true;
            }
            return false;
        }
        
        }
    }


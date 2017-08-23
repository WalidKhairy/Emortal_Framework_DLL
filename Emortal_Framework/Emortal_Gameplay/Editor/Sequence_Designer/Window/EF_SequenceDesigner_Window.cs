using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Emortal.Gameplay
{
    public class EF_SequenceDesigner_Window : EditorWindow 
    {
        #region Variables
        static EF_SequenceDesigner_Window m_CurWindow;
        static string m_DataPath;

        Event curEvent;
        Vector2 scrollPos = Vector2.zero;

        static EF_Graph_View graphView;

        Rect windowRect;
        #endregion




        #region Init Methods
        public static void InitSequenceDesigner()
        {
            //Create the window
            m_CurWindow = (EF_SequenceDesigner_Window)EditorWindow.GetWindow(typeof(EF_SequenceDesigner_Window));

            GUIContent titleContent = new GUIContent("Sequence Designer");
            m_CurWindow.titleContent = titleContent;

            CreateViews();
        }

        public static void InitSequenceDesigner(string assetLocation)
        {
            //Create the window
            m_CurWindow = (EF_SequenceDesigner_Window)EditorWindow.GetWindow(typeof(EF_SequenceDesigner_Window));

            GUIContent titleContent = new GUIContent("Sequence Designer");
            m_CurWindow.titleContent = titleContent;

            CreateViews();
        }

        static void CreateViews()
        {
            graphView = new EF_Graph_View();
        }
        #endregion





        #region Main Methods
        void Update()
        {
            if(m_CurWindow == null)
            {
                InitSequenceDesigner();
                return;
            }
        }

        void OnGUI()
        {
            //Start getting Events
            curEvent = Event.current;
            HandleEvents();


            //Draw the Toolbar
            DrawToolBar();

            //Make sure we have the views before proceeding
            if(graphView == null)
            {
                graphView = new EF_Graph_View();
                return;
            }
            scrollPos = GUILayout.BeginScrollView(scrollPos, true, true);

            GUILayout.Label("", GUILayout.Width(10000f), GUILayout.Height(10000f));
            graphView.DrawView();

            GUILayout.EndScrollView();


            Repaint();
        }


        /// <summary>
        /// Handles the events of the mouse
        /// </summary>
        void HandleEvents()
        {
            if(curEvent.isMouse)
            {
                switch(curEvent.button)
                {
                    //Left Mouse Button
                    case 0:
                        break;

                    //Right Mouse Button
                    case 1:
                        break;

                    //Middle Mouse Button
                    case 2:
                        if(curEvent.type == EventType.MouseDrag)
                        {
                            scrollPos -= curEvent.delta;
                        }break;

                    default:
                        break;
                }
            }
        }
        #endregion






        #region Helpers
        void DrawToolBar()
        {
            GUILayout.BeginVertical(EditorStyles.toolbar);
            GUILayout.BeginHorizontal(EditorStyles.toolbar);


            if(GUILayout.Button("Options", EditorStyles.toolbarButton))
            {
                
            }

            if(GUILayout.Button("Settings", EditorStyles.toolbarButton))
            {

            }

            if(GUILayout.Button("Help", EditorStyles.toolbarButton))
            {

            }



            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();

        }
        #endregion
    }
}

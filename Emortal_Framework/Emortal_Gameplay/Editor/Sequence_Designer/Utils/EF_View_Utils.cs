using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Emortal.Gameplay
{
    public static class EF_View_Utils 
    {
        public static void DrawGraphGrid(Rect viewRect, float gridSpacing, float gridOpacity, Color gridColor)
        {
            int widthDivs = Mathf.CeilToInt(viewRect.width / gridSpacing);
            int heightDivs = Mathf.CeilToInt(viewRect.height / gridSpacing);

            Handles.BeginGUI();
            Handles.color = new Color(gridColor.r, gridColor.g, gridColor.b, gridOpacity);
            for(int x = 0; x < widthDivs; x++)
            {
                Handles.DrawLine(new Vector3((gridSpacing * x), 0f, 0f), new Vector3((gridSpacing * x), viewRect.height, 0f));
            }

            for(int y = 0; y < heightDivs; y++)
            {
                Handles.DrawLine(new Vector3(0f, (gridSpacing * y), 0f), new Vector3(viewRect.width, (gridSpacing * y), 0f));
            }

            Handles.color = Color.white;
            Handles.EndGUI();
        }
    }
}

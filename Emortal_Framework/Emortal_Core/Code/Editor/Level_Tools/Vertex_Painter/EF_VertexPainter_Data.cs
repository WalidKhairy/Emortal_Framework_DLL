using UnityEngine;
using System;

namespace Emortal.Core
{
    #region Structs
    [Serializable]
    public struct EF_MouseData
    {
        public Vector2 mousePos;
        public bool leftClickHold;
        public bool leftClick;
        public bool rightClick;
        public bool rightClickHold;
        public Vector2 mouseDelta;
    };

    [Serializable]
    public struct EF_BrushData
    {
        public float brushSize;
        public float falloffSize;
        public float opacity;
        public float sculptIntensity;
        public float startHeight;
        public Color brushColor;
        public EF_SculptState sculptState;
        public int sculptDir;

        public EF_BrushData(float aSize, float aFalloff, float anOpacity, 
            Color aColor, EF_SculptState aSculptState, float aIntensity, int aSculptDir,
            float aStartHeight)
        {
            brushSize = aSize;
            falloffSize = aFalloff;
            opacity = anOpacity;
            startHeight = aStartHeight;
            sculptIntensity = aIntensity;
            sculptDir = aSculptDir;
            brushColor = aColor;
            sculptState = aSculptState;
        }
    };
    #endregion


    #region Enums
    public enum EF_SculptState
    {
        NormalDir = 0,
        WorldUpDir = 1,
        Flatten = 2,
    }

    public enum EF_VTXPainterState
    {
        None = 0,
        Painting = 1,
        Sculpting = 2,
        Instancing = 3,
    }
    #endregion
}

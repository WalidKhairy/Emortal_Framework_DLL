using UnityEditor;
using UnityEngine;

namespace Emortal.Core
{
    public class EF_Menus 
    {
        #region Core Menus
        [MenuItem("Emortal/Designer Dashboard")]
        public static void LaunchDesignerDashboard()
        {
            EF_DesignerDash_Window.InitDesignerDashboard();
        }
        #endregion



        #region Project Tools Menus
        [MenuItem("Emortal/Project Tools/Create Project Folders")]
        public static void CreateProjectFolders()
        {
            EF_ProjectFolders_Window.InitWindow();
        }
        #endregion




        #region Scene Helpers Menus
        [MenuItem("Emortal/Scene Tools/Create Game Manager")]
        public static void CreateGameManager()
        {
            EF_Scene_Helpers.CreateGameManager();
        }

        [MenuItem("Emortal/Scene Tools/Group Selected")]
        public static void GroupSelectedGameObjects()
        {
            EF_Grouping_Window.InitWindow();
        }

        [MenuItem("Emortal/Scene Tools/Object Replacement")]
        public static void ReplaceSelectedGameObjects()
        {
            EF_ObjectReplacer_Window.InitWindow();
        }

        [MenuItem("Emortal/Scene Tools/Create Level Manager")]
        public static void CreateLevelController()
        {
            EF_Scene_Helpers.CreateLevelGroup();
        }

        [MenuItem("Emortal/Scene Tools/Create Inputs")]
        public static void CreateInputs()
        {
            EF_Scene_Helpers.CreateInputs();
        }
        #endregion



        #region Level Tools
        [MenuItem("Emortal/Level Tools/Vertex Painter")]
        public static void LaunchVertexPainter()
        {
            EF_VertexPainter_Tool.LaunchVertexPainter();
        }

        [MenuItem("Emortal/Level Tools/Export Selected to Single OBJ")]
        public static void ExportSelectedToOBJ()
        {
            EF_OBJ_Export.ExportWholeSelectionToSingle();
        }

        [MenuItem("Emortal/Level Tools/Export Each Selected to OBJ")]
        public static void ExportAllToOBJ()
        {
            EF_OBJ_Export.ExportEachSelectionToSingle();
        }
        #endregion




//        #region Camera Helpers
//        [MenuItem("Emortal/Cameras/Create Free Fly Camera")]
//        public static void CreateFreeFlyCamera()
//        {
//            EF_Camera_Helpers.CreateCameraRig(0);
//        }
//
//        [MenuItem("Emortal/Cameras/Create FPS Camera")]
//        public static void CreateFPSCamera()
//        {
//            EF_Camera_Helpers.CreateCameraRig(1);
//        }
//
//        [MenuItem("Emortal/Cameras/Create 3rd Person Camera")]
//        public static void CreateThirdPersonCamera()
//        {
//            EF_Camera_Helpers.CreateCameraRig(2);
//        }
//
//        [MenuItem("Emortal/Cameras/Create RTS Camera")]
//        public static void CreateRTSCamera()
//        {
//            EF_Camera_Helpers.CreateCameraRig(3);
//        }
//        #endregion



        #region UI Helpers
        [MenuItem("Emortal/UI Tools/Create UI Canvas Grp")]
        public static void CreateUICanvasGroup()
        {
            EF_UI_Helpers.CreateUIGroup();
        }

        [MenuItem("Emortal/UI Tools/Screen Templates/Create Base Screen")]
        public static void CreateBaseUIScreen()
        {
            EF_UI_Helpers.CreateUIScreen(ScreenTypes.Base);
        }

        [MenuItem("Emortal/UI Tools/Screen Templates/Create Timed Screen")]
        public static void CreateTimedUIScreen()
        {
            EF_UI_Helpers.CreateUIScreen(ScreenTypes.Timed);
        }
        #endregion

    }
}

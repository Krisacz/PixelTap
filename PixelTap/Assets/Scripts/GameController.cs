using Assets.Scripts.GameScreens;
using Assets.Scripts.Models;
using Assets.Scripts.Models.GData;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        public static GameScreenType ActiveGameScreen = GameScreenType.None;

        public void Start()
        {
            //===== GAME START =====
            //===== GAME START =====
            //===== GAME START =====

            //----- LOAD DATA -----
            GameSave.Load();
            var gameData = GameSave.Get();
            ActiveGameScreen = gameData.ActiveGameScreen;

            //----- SET ALL STATISTICS -----
            StatsController.Inst.Init(gameData.StatsData);

            //----- INITIALIZE SCREENS -----
            InitGameScreens(gameData.SectorData);

            //----- POSITION CAMERA -----
            CameraController.MoveToGameScreen(gameData.ActiveGameScreen, true);
            
            //----- UPDATE UI VIEW -----
            UIController.Inst.ButtonsEnable(ActiveGameScreen);
        }

        #region INIT GAME SCREENS
        private static void InitGameScreens(SectorData sectorData)
        {
            HqViewController.Inst.Init(sectorData.HqViewData);
            HqViewController.Inst.SetEnabled();

            GeneratorController.Inst.Init(sectorData.GeneratorData);
            GeneratorController.Inst.SetEnabled();

            WorkshopController.Inst.Init(sectorData.WorkshopData);
            WorkshopController.Inst.SetEnabled();

            HqUpgradeController.Inst.Init(sectorData.HqUpgradeData);
            HqUpgradeController.Inst.SetEnabled();

            LabController.Inst.Init(sectorData.LabData);
            LabController.Inst.SetEnabled();
            
            PortalController.Inst.Init(sectorData.PortalData);
            PortalController.Inst.SetEnabled();

            ArtifactController.Inst.Init(sectorData.ArtifactData);
            ArtifactController.Inst.SetEnabled();

            PixelClusterAlphaController.Inst.Init(sectorData.PixelClusterAlpha);
            PixelClusterAlphaController.Inst.SetEnabled();

            PixelClusterBetaController.Inst.Init(sectorData.PixelClusterBeta);
            PixelClusterBetaController.Inst.SetEnabled();

            PixelClusterGammaController.Inst.Init(sectorData.PixelClusterGamma);
            PixelClusterGammaController.Inst.SetEnabled();

        }
        #endregion
    }
}

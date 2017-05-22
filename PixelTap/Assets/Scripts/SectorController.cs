using Assets.Scripts.Models;
using Assets.Scripts.Models.GData;
using UnityEngine;

namespace Assets.Scripts
{
    public class SectorController : MonoBehaviour
    {
        public static SectorController Inst;
        private SectorInfo _sectorInfo;

        public void OnEnable()
        {
            GenerateSector();
        }

        public void Start ()
        {
            Inst = this;
        }

        private void GenerateSector()
        {
            //_sectorInfo = new SectorInfo(false, false, false, false, false, false, false, false, false, false);
            //_sectorInfo = new SectorInfo(true, true, true, false, true, true, true, true, false, false);

            _sectorInfo = new SectorInfo(true, true, true, true, true, true, true, true, true, true);
            CameraController.SetToGameScreen(GameScreenType.HQView);
        }

        public SectorInfo GetSectorInfo()
        {
            return _sectorInfo;
        }
    }
}
using System;
using System.Collections;
using Assets.Scripts.GameScreens;
using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class UIController : MonoBehaviour
    {
        public static UIController Inst;

        private GameObject _hqViewButton;
        private GameObject _generatorButton;
        private GameObject _workshopButton;
        private GameObject _hqUpgradeButton;
        private GameObject _labButton;

        private GameObject _portalButton;
        private GameObject _artifactButton;
        private GameObject _pixelCluster1Button;
        private GameObject _pixelCluster2Button;
        private GameObject _pixelCluster3Button;

        void Start ()
        {
            Inst = this;

            #region COLLECT GO'S FROM TAGS
            _hqViewButton = GameObject.FindWithTag(Tags.HQView_Button.ToString());
            _generatorButton = GameObject.FindWithTag(Tags.Generator_Button.ToString());
            _workshopButton = GameObject.FindWithTag(Tags.Workshop_Button.ToString());
            _hqUpgradeButton = GameObject.FindWithTag(Tags.HQUpgrade_Button.ToString());
            _labButton = GameObject.FindWithTag(Tags.Lab_Button.ToString());

            _portalButton = GameObject.FindWithTag(Tags.Portal_Button.ToString());
            _artifactButton = GameObject.FindWithTag(Tags.Artifact_Button.ToString());
            _pixelCluster1Button = GameObject.FindWithTag(Tags.PixelCluster1_Button.ToString());
            _pixelCluster2Button = GameObject.FindWithTag(Tags.PixelCluster2_Button.ToString());
            _pixelCluster3Button = GameObject.FindWithTag(Tags.PixelCluster3_Button.ToString());
            #endregion
        }

        #region BUTTONS SHOW/HIDE
        private const float StartDelay = 0.1f;
        private const float DiffDelay = 0.1f;
        private static float _delay;
        public void ButtonsShowHide(bool show)
        {
            _delay = StartDelay;
            ButtonShowHide(_portalButton, show);
            ButtonShowHide(_artifactButton, show);
            ButtonShowHide(_pixelCluster1Button, show);
            ButtonShowHide(_pixelCluster2Button, show);
            ButtonShowHide(_pixelCluster3Button, show);

            _delay = StartDelay;
            ButtonShowHide(_hqViewButton, show);
            ButtonShowHide(_generatorButton, show);
            ButtonShowHide(_workshopButton, show);
            ButtonShowHide(_hqUpgradeButton, show);
            ButtonShowHide(_labButton, show);
        }

        private static void ButtonShowHide(GameObject go, bool show)
        {
            //Bail out if not active
            if(!go.activeSelf) return;

            //Upd delay
            _delay += DiffDelay;

            //Disable
            go.GetComponent<Button>().enabled = false;

            var image = go.GetComponent<Image>();
            var text = go.GetComponentInChildren<Text>();

            var tweenParams = new Hashtable();
            tweenParams.Add("from", show ? 0f : 1f);
            tweenParams.Add("to", show ? 1f : 0f);
            tweenParams.Add("time", 0.4f);
            tweenParams.Add("delay", _delay);
            tweenParams.Add("onupdate", 
                (Action<object>)(newValue =>
                                 {
                                     var currSprColor = image.color;
                                     currSprColor.a = (float)newValue;
                                     image.color = currSprColor;

                                     var currTxtColor = text.color;
                                     currTxtColor.a = (float)newValue;
                                     text.color = currTxtColor;
                                 }));
            tweenParams.Add("oncomplete", (Action<object>)(newValue => { go.GetComponent<Button>().enabled = true; })); 

            iTween.ValueTo(go, tweenParams);
        }
        #endregion

        #region BUTTONS ACTIVATE
        public void ButtonsEnable(GameScreenType gameScreen)
        {
            switch (gameScreen)
            {
                case GameScreenType.None:
                    break;

                case GameScreenType.HQView:
                    ButtonEnable(HqViewController.Inst.GetButtonsVisibility());
                    break;

                case GameScreenType.Generator:
                    ButtonEnable(GeneratorController.Inst.GetButtonsVisibility());
                    break;

                case GameScreenType.Workshop:
                    ButtonEnable(HqViewController.Inst.GetButtonsVisibility());
                    break;

                case GameScreenType.HQUpgrade:
                    ButtonEnable(WorkshopController.Inst.GetButtonsVisibility());
                    break;
                
                case GameScreenType.Lab:
                    ButtonEnable(LabController.Inst.GetButtonsVisibility());
                    break;

                case GameScreenType.Portal:
                    ButtonEnable(PortalController.Inst.GetButtonsVisibility());
                    break;

                case GameScreenType.Artifact:
                    ButtonEnable(ArtifactController.Inst.GetButtonsVisibility());
                    break;

                case GameScreenType.PixelClusterAlpha:
                    ButtonEnable(PixelClusterAlphaController.Inst.GetButtonsVisibility());
                    break;

                case GameScreenType.PixelClusterBeta:
                    ButtonEnable(PixelClusterBetaController.Inst.GetButtonsVisibility());
                    break;

                case GameScreenType.PixelClusterGamma:
                    ButtonEnable(PixelClusterGammaController.Inst.GetButtonsVisibility());
                    break;

                default: throw new ArgumentOutOfRangeException("gameScreen", gameScreen, null);
            }
        }

        private void ButtonEnable(ButtonsVisibility bs)
        {
            _hqViewButton.SetActive(        HqViewController.Inst.IsEnabled             && bs.HQView);
            _generatorButton.SetActive(     GeneratorController.Inst.IsEnabled          && bs.Generator);
            _workshopButton.SetActive(      WorkshopController.Inst.IsEnabled           && bs.Workshop);
            _hqUpgradeButton.SetActive(     HqUpgradeController.Inst.IsEnabled          && bs.HQUpgrade);
            _labButton.SetActive(           LabController.Inst.IsEnabled                && bs.Lab);

            _portalButton.SetActive(        PortalController.Inst.IsEnabled             && bs.Portal);
            _artifactButton.SetActive(      ArtifactController.Inst.IsEnabled           && bs.Artifact);
            _pixelCluster1Button.SetActive( PixelClusterAlphaController.Inst.IsEnabled  && bs.PixelCluster1);
            _pixelCluster2Button.SetActive( PixelClusterBetaController.Inst.IsEnabled   && bs.PixelCluster2);
            _pixelCluster3Button.SetActive( PixelClusterGammaController.Inst.IsEnabled  && bs.PixelCluster3);
        }
        #endregion
    }
}

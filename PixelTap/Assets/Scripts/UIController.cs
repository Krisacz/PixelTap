using System;
using System.Collections;
using Assets.Scripts;
using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

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
    }

    #region HIDE ALL
    private const float StartDelay = 0.1f;
    private const float DiffDelay = 0.1f;
    private static float _delay;
    public void ButtonsRender(bool show)
    {
        _delay = StartDelay;
        HideShow(_portalButton, show);
        HideShow(_artifactButton, show);
        HideShow(_pixelCluster1Button, show);
        HideShow(_pixelCluster2Button, show);
        HideShow(_pixelCluster3Button, show);

        _delay = StartDelay;
        HideShow(_hqViewButton, show);
        HideShow(_generatorButton, show);
        HideShow(_workshopButton, show);
        HideShow(_hqUpgradeButton, show);
        HideShow(_labButton, show);
    }

    private static void HideShow(GameObject go, bool show)
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

    #region ACTIVATE
    public void ActivateGameScreenUI(GameScreen gameScreen)
    {
        switch (gameScreen)
        {
            case GameScreen.None:
                break;

            case GameScreen.HQView:
                ButtonsSetActive(false, true, true, true, true, true, true, true, true, true);
                break;

            case GameScreen.Generator:
                ButtonsSetActive(true, false, false, false, false, false, false, false, false, false);
                break;

            case GameScreen.Workshop:
                ButtonsSetActive(true, false, false, false, false, false, false, false, false, false);
                break;

            case GameScreen.HQUpgradeView:
                ButtonsSetActive(true, false, false, false, false, false, false, false, false, false);
                break;
                
            case GameScreen.Lab:
                ButtonsSetActive(true, false, false, false, false, false, false, false, false, false);
                break;

            case GameScreen.Portal:
                ButtonsSetActive(true, false, false, false, false, false, true, true, true, true);
                break;

            case GameScreen.Artifact:
                ButtonsSetActive(true, false, false, false, false, true, false, true, true, true);
                break;

            case GameScreen.PixelCluster1:
                ButtonsSetActive(true, false, false, false, false, false, false, false, true, true);
                break;

            case GameScreen.PixelCluster2:
                ButtonsSetActive(true, false, false, false, false, false, false, true, false, true);
                break;

            case GameScreen.PixelCluster3:
                ButtonsSetActive(true, false, false, false, false, false, false, true, true, false);
                break;

            default: throw new ArgumentOutOfRangeException("gameScreen", gameScreen, null);
        }
    }

    private void ButtonsSetActive(bool hqView, bool gen, bool workshop, bool hqUpgrade, bool lab, bool portal, bool artifact, bool pc1, bool pc2, bool pc3)
    {
        _hqViewButton.SetActive(hqView);
        _generatorButton.SetActive(gen);
        _workshopButton.SetActive(workshop);
        _hqUpgradeButton.SetActive(hqUpgrade);
        _labButton.SetActive(lab);

        _portalButton.SetActive(portal);
        _artifactButton.SetActive(artifact);
        _pixelCluster1Button.SetActive(pc1);
        _pixelCluster2Button.SetActive(pc2);
        _pixelCluster3Button.SetActive(pc3);
    }

    #endregion
}

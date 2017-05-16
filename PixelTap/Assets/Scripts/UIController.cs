using System;
using System.Collections;
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
    public void ButtonsRender(bool hide)
    {
        _delay = StartDelay;
        HideShow(_portalButton, hide);
        HideShow(_artifactButton, hide);
        HideShow(_pixelCluster1Button, hide);
        HideShow(_pixelCluster2Button, hide);
        HideShow(_pixelCluster3Button, hide);

        _delay = StartDelay;
        HideShow(_hqViewButton, hide);
        HideShow(_generatorButton, hide);
        HideShow(_workshopButton, hide);
        HideShow(_hqUpgradeButton, hide);
        HideShow(_labButton, hide);
    }

    private static void HideShow(GameObject go, bool isHiding)
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
        tweenParams.Add("from", isHiding ? 1f : 0f);
        tweenParams.Add("to", isHiding ? 0f : 1f);
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

        iTween.ValueTo(go, tweenParams);
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour
{
    private bool _flag = true;

    void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.Return))
	    {
	        UIController.Inst.ButtonsRender(_flag);
	        _flag = !_flag;
	    }
	}
}

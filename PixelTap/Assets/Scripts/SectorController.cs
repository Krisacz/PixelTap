using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorController : MonoBehaviour
{
    public static SectorController Inst;
    
    public bool PixelCluster1 { get; private set; }
    
	void Start ()
	{
	    Inst = this;
	}

    public void Init()
    {
        
    }

}

public class SectorInfo
{
    
}

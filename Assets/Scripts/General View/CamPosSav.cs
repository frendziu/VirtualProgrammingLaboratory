using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPosSav
{
    private static Vector3 myCamPos;
    public static Vector3 MyCamPos
    {
        get { return myCamPos; }
        set { myCamPos = value; }
    }
}

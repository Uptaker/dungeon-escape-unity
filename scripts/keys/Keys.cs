using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public bool hasPurpleKey = false;
    public bool hasBlueKey = false;
    public bool hasRedKey = false;

    public void toggleBlue()
    {
        hasBlueKey = true;
    }

    public void togglePurple()
    {
        hasPurpleKey = true;
    }

    public void toggleRed()
    {
        hasRedKey = true;
    }
}

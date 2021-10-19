using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKeyScript : MonoBehaviour, KeyScript
{

    public CharacterController player;

    public void CustomFunction()
    {
        player.GetComponent<Keys>().toggleRed();
        Debug.Log("Red KEY AQUIRED");
    }

    public bool CanInteract()
    {
        if (player.GetComponent<Keys>().hasBlueKey)
        {
            return true;
        } else
        {
            return false;
        }
    }

}



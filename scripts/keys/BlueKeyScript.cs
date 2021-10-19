using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKeyScript : MonoBehaviour, KeyScript
{

    public CharacterController player;

    public void CustomFunction()
    {
        player.GetComponent<Keys>().toggleBlue();
    }

    public bool CanInteract()
    {
        return true;
    }

}


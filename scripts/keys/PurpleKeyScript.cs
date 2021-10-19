using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleKeyScript : MonoBehaviour, KeyScript
{

    public CharacterController player;
    public bool CanInteract()
    {
        return true;
    }

    public void CustomFunction()
    {
        player.GetComponent<Keys>().togglePurple();
    }
}

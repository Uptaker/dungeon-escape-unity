using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoorScript : MonoBehaviour, KeyScript
{

    public CharacterController player;
    public bool CanInteract()
    {
        if (player.GetComponent<Keys>().hasRedKey)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public void CustomFunction()
    {
        throw new System.NotImplementedException();
    }
}

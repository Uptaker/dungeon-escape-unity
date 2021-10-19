using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Q3Movement;

public class AddMultiJump : MonoBehaviour, KeyScript

{

    public CharacterController player;

    public bool CanInteract()
    {
        return true;
    }

    public void CustomFunction()
    {
        player.GetComponent<QuakeMovement>().hasDoubleJump = true;
    }
}

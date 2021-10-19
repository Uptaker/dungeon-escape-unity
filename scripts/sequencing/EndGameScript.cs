using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Q3Movement;

public class EndGameScript : MonoBehaviour
{

    public CharacterController player;
    public GameObject endText;

    private void OnTriggerEnter(Collider player)
    {
        endText.GetComponent<Text>().enabled = true;
        player.GetComponent<Q3Movement.QuakeMovement>().enabled = false;
        StartCoroutine(endGame());
    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("main_menu");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}

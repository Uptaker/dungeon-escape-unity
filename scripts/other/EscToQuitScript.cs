using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscToQuitScript : MonoBehaviour
{
    public CharacterController player;

    private void Start()
    {
        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            player.GetComponent<Q3Movement.QuakeMovement>().enabled = false;
            SceneManager.LoadScene("main_menu");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

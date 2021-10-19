using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using Q3Movement;

public class AOpening : MonoBehaviour
{

    public GameObject player;
    public GameObject fadeScreenIn;
    public GameObject textBox;

    void Start()
    {
        player.GetComponent<QuakeMovement>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer() {
        yield return new WaitForSeconds(1.5f);
        fadeScreenIn.SetActive(false);
        textBox.GetComponent<Text>().text = "I need to get out of here.";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "";
        player.GetComponent<QuakeMovement>().enabled = true;
    }
}

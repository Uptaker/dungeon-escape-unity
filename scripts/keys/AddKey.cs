using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddKey : MonoBehaviour
{

    public float distance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject key;
    public GameObject extraCross;
    public GameObject textObject;
    public string actionString;
    public string examineText;
    public KeyScript script;
    public bool destroyAfterInteraction = true;
    public string cantInteractMessage;
    AudioSource use;


    void Start()
    {
        toggleUI(false);
        script = GetComponent<KeyScript>();

        // play audio from file
         use = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        distance = PlayerCasting.distanceFromTarget;
    }

    void OnMouseOver()
    {

        if (distance <= 2.5)
        {
            actionText.GetComponent<Text>().text = actionString;
            toggleUI(true);
        }

        Debug.Log("I'm looking");

        if (Input.GetButtonDown("Action") && distance <= 2.5)
        {

            if (script.CanInteract())
            {
                textObject.GetComponent<Text>().enabled = true;
                textObject.GetComponent<Text>().text = examineText;

                toggleUI(false);
                //creakSound.Play();
                this.GetComponent<BoxCollider>().enabled = false;
                if (destroyAfterInteraction)
                {
                    Destroy(key);
                }
                script.CustomFunction();
                StartCoroutine(removeExamineText());
            } else
            {
                textObject.GetComponent<Text>().enabled = true;
                textObject.GetComponent<Text>().text = cantInteractMessage;

                toggleUI(false);

                StartCoroutine(removeExamineText());
            }
            use.PlayOneShot((AudioClip)Resources.Load("use"));
        }

        if (distance >= 2.5)
        {
            toggleUI(false);
        }
    }

    void toggleUI(bool state)
    {
        if (state == true)
        {
            actionDisplay.GetComponent<Text>().enabled = true;
            actionText.GetComponent<Text>().enabled = true;
            extraCross.GetComponent<RawImage>().enabled = true;
        }
        else
        {
            actionDisplay.GetComponent<Text>().enabled = false;
            actionText.GetComponent<Text>().enabled = false;
            extraCross.GetComponent<RawImage>().enabled = false;
        }
    }

    void OnMouseExit()
    {
        toggleUI(false);
    }

    IEnumerator removeExamineText()
    {
        yield return new WaitForSeconds(4f);
        textObject.GetComponent<Text>().text = "";

    }
}
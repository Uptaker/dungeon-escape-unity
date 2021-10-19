using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorCellOpen : MonoBehaviour
{

    public float distance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject door;
    public AudioSource creakSound;
    public GameObject extraCross;
    public GameObject textObject;
    public bool isOpen = false;
    public KeyScript script;
    public string cantInteractMessage = "The door is locked";

    void Start() {
        toggleUI(false);
        script = GetComponent<KeyScript>();
    }

    void Update()
    {
        distance = PlayerCasting.distanceFromTarget;
    }

    void OnMouseOver() {
        if (distance <= 2.5) {
            toggleUI(true);
            if (isOpen)
            {
                actionText.GetComponent<Text>().text = "Close door";
            } else
            {
                actionText.GetComponent<Text>().text = "Open door";
            }
        }

        if (Input.GetButtonDown("Action") && distance <= 2.5) {
            // 'this' refers to the name of the object the script is attached to
            Debug.Log("has key: " + script.CanInteract());
            if (script.CanInteract())
            {
                Debug.Log("opening door");
                if (!isOpen)
                {
                    actionText.GetComponent<Text>().text = "Close door";
                    this.GetComponent<BoxCollider>().enabled = false;
                    door.GetComponent<Animation>().Play("FirstDoorOpenAnim");
                    isOpen = true;
                    StartCoroutine(DelayColliderToggle());
                }
                else
                {
                    actionText.GetComponent<Text>().text = "Open door";
                    this.GetComponent<BoxCollider>().enabled = false;
                    door.GetComponent<Animation>().Play("DoorCloseAnim");
                    isOpen = false;
                    StartCoroutine(DelayColliderToggle());
                }
                toggleUI(false);
                creakSound.Play();
            } else {
                Debug.Log("can't open door");
                textObject.GetComponent<Text>().enabled = true;
                textObject.GetComponent<Text>().text = cantInteractMessage;

                toggleUI(false);

                StartCoroutine(removeExamineText());
            }


        }

        if (distance > 2.5) {
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

    void OnMouseExit() {
        toggleUI(false);
    }

    IEnumerator DelayColliderToggle()
    {
        yield return new WaitForSeconds(1.5f);
        this.GetComponent<BoxCollider>().enabled = true;

    }

    IEnumerator removeExamineText()
    {
        yield return new WaitForSeconds(4f);
        textObject.GetComponent<Text>().text = "";

    }
}

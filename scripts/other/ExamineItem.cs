using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExamineItem : MonoBehaviour
{

    public float distance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject extraCross;
    public GameObject textObject;
    public GameObject otherTextObject;
    public string actionString = "";
    bool colliding = false;

    [TextArea]
    public string examineText = "";
    AudioSource use;


    void Start()
    {

        // Attach GameObject
        actionDisplay = GameObject.Find("/Canvas/ActionKey");
        if (actionDisplay == null)
        {
            actionDisplay = GameObject.Find("/Canvas/ActionKey");
        }
        actionText = GameObject.Find("/Canvas/ActionText");
        extraCross = GameObject.Find("/Canvas/ExtraCrosshair");
        textObject = GameObject.Find("/Canvas/ExamineText");
        otherTextObject = GameObject.Find("/Canvas/Text");

        toggleUI(false);

        // Play audio from file
        use = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        distance = PlayerCasting.distanceFromTarget;
    }

    void toggleUI(bool state)
    {
        if (state == true)
        {
            actionDisplay.GetComponent<Text>().enabled = true;
            actionText.GetComponent<Text>().enabled = true;
            extraCross.GetComponent<RawImage>().enabled = true;
        } else
        {
            actionDisplay.GetComponent<Text>().enabled = false;
            actionText.GetComponent<Text>().enabled = false;
            extraCross.GetComponent<RawImage>().enabled = false;
        }
    }

    void OnMouseOver()
    {

        if (distance <= 2.5 || colliding)
        {
            actionText.GetComponent<Text>().text = actionString;
            toggleUI(true);
        }

        Debug.Log("I'm looking");

        if (Input.GetButtonDown("Action") && (distance <= 2.5 || colliding))
        {
            otherTextObject.GetComponent<Text>().text = "";
            textObject.GetComponent<TextMeshProUGUI>().enabled = true;
            textObject.GetComponent<TextMeshProUGUI>().text = examineText;

            toggleUI(false);

            StartCoroutine(removeExamineText());

            use.PlayOneShot((AudioClip)Resources.Load("use"));
        }

        if (distance >= 2.5 && !colliding)
        {
            toggleUI(false);
        }
    }

    void OnMouseExit()
    {
        toggleUI(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        colliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        colliding = false;
    }

    IEnumerator removeExamineText()
    {
        yield return new WaitForSeconds(7f);
        textObject.GetComponent<TextMeshProUGUI>().text = "";

    }
}
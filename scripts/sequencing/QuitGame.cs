using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class QuitGame : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<TextMeshProUGUI>().faceColor = new Color32(231, 172, 97, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<TextMeshProUGUI>().faceColor = new Color32(243, 243, 243, 255);
    }
}


using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEvent : MonoBehaviour   
    , IPointerEnterHandler
    , IPointerExitHandler
{
    

    public TextMeshProUGUI tm;

    public void OnPointerEnter(PointerEventData eventData)
    {
        tm.fontSize += 5;
        tm.color = new Color(255, 255, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tm.fontSize -= 5;
        tm.color = new Color(0, 0, 0);
    }
}

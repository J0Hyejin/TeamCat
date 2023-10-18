using TMPro;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    public TextMeshProUGUI tm;

    void OnMouseEnter()
    {
        tm.fontSize = 100;    
    }

    private void OnMouseExit()
    {
        tm.fontSize = 80;
    }
}

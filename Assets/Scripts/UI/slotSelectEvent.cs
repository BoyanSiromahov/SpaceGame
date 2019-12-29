using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class slotSelectEvent : MonoBehaviour, IPointerClickHandler
{
    public int slot;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        GetComponent<Image>().color = new Color32(0, 72, 225, 100);
        GetComponent<Transform>().parent.parent.parent.GetComponent<moduleManager>().select(slot);
    }

    public void unSelect()
    {
        GetComponent<Image>().color = new Color32(255, 10, 0, 100);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrollviewController : MonoBehaviour
{
    public GameObject content;
    RectTransform rt;
    float width = 0;
    float height = 0;
    public float cWidth;
    public float cheight;
    public bool changeWidth;
    public bool changeHeight;
    public void Start()
    {
            rt = content.GetComponent<RectTransform>();

        foreach(RectTransform child in rt)
        {
            width += cWidth;
            height += cheight;
        }

        if (!changeWidth)
        {
            width = content.GetComponent<RectTransform>().rect.width;
        }

        if (!changeHeight)
        {
            height = content.GetComponent<RectTransform>().rect.height;
        }
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(height, width);
    }

}

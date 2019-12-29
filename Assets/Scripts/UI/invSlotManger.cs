using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class invSlotManger : MonoBehaviour
{
    public GameObject item;
    private Text nameTxt;
    private RawImage itemImage;
    public int numItems = -1;
    private ArrayList items = new ArrayList();
    public GameObject slotManager;
    public GameObject slotPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (numItems == -1 || numItems == 0)
            {
                numItems = 1;
            }

            for (int i = 0; i < numItems; i++)
            {
                addItem(item);
            }
        }
    }

    public void addItem(GameObject nitem)
    {
        itemProperties itemProperties = nitem.GetComponentInChildren<itemProperties>();
        if (items.Contains(nitem))
        {
            foreach(Transform child in slotManager.GetComponent<Transform>())
            {
                if (child.transform.GetChild(3).GetComponent<Text>().text == itemProperties.itemName)
                {
                    var value = child.transform.GetChild(0).GetComponent<Text>().text;
                    child.transform.GetChild(0).GetComponent<Text>().text = (Int32.Parse(value) + 1).ToString();
                }
            }
        }
        else
        {
            items.Add(nitem);
            GameObject slot = (GameObject)Instantiate(slotPrefab, slotManager.transform);

            //quantity text
            slot.transform.GetChild(0).GetComponent<Text>().text = "1";
            //description text
            slot.transform.GetChild(1).GetComponent<Text>().text = itemProperties.description;
            //value text
            slot.transform.GetChild(2).GetComponent<Text>().text = itemProperties.value.ToString();
            //name text
            slot.transform.GetChild(3).GetComponent<Text>().text = itemProperties.itemName;
            //raw image
            slot.transform.GetChild(4).GetComponent<RawImage>().texture = Resources.Load(itemProperties.path) as Texture2D;
            Vector2 smSize = slotManager.GetComponent<RectTransform>().sizeDelta;
            Vector2 slotSize = slot.GetComponent<RectTransform>().sizeDelta;
            slotManager.GetComponent<RectTransform>().sizeDelta = new Vector2(smSize.x, smSize.y + slotSize.y + 5);
        }
    }
}

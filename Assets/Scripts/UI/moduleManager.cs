using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moduleManager : MonoBehaviour
{
    public GameObject item;
    private Text nameTxt;
    private RawImage itemImage;
    public Dropdown dp;
    public int numItems = -1;
    private ArrayList items;
    public GameObject slotManager;
    public GameObject slotPrefab;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.N)) 
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
        GameObject slot = (GameObject) Instantiate(slotPrefab, slotManager.transform);

        slot.transform.GetChild(0).GetComponent<RawImage>().texture = Resources.Load(itemProperties.path) as Texture2D;
        slot.transform.GetChild(1).GetComponent<Text>().text = itemProperties.itemName;
        Vector2 smSize = slotManager.GetComponent<RectTransform>().sizeDelta;
        Vector2 slotSize = slot.GetComponent<RectTransform>().sizeDelta;
        slotManager.GetComponent<RectTransform>().sizeDelta = new Vector2(smSize.x, smSize.y + slotSize.y + 5);
    }
    public void onDropdownChanged()
    {
        //TODO pull from inv
    }

}

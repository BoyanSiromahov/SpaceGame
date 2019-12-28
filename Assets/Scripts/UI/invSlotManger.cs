using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invSlotManger : MonoBehaviour
{
    public GameObject item;
    public Text quantityTxt ;
    public Text descriptionTxt;
    public Text nameTxt;
    public Text valueTxt;
    public RawImage itemImage;

    void Start()
    {
        addItem(item);
    }

    public void addItem(GameObject nitem)
    {
        if (item == null)
        {
            item = nitem;
        }

        itemProperties itemProperties = item.GetComponentInChildren<itemProperties>();

        descriptionTxt.text = itemProperties.description;
        nameTxt.text = itemProperties.itemName;
        quantityTxt.text = 1.ToString();
        valueTxt.text = itemProperties.value.ToString();
        itemImage.texture =  Resources.Load(itemProperties.path) as Texture2D;
    }

    public void removeItem()
    {
        if (item != null)
        {
            item = null;
        }
    }

    public GameObject getItem()
    {
        return item;
    }

    public void setDescription(string description)
    {
        descriptionTxt.text = description;
    }

    public void setQuantity(int quantity)
    {
        quantityTxt.text = quantity.ToString();
    }

    public void setName(string name)
    {
        nameTxt.text = name;
    }

    public void setValue(int value)
    {
        valueTxt.text = value.ToString();
    }
}

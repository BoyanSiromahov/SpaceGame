using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpHandler : MonoBehaviour
{
    private Transform st;
    private Transform at;
    private Transform ht;
    public GameObject player;
    private float shieldMax, armorMax, hullMax;
    private float shieldCur, armorCur, hullCur;
    private float sWidth, aWidth, hWidth;
    private Text sAmount, aAmount, hAmount;

    // Start is called before the first frame update
    void Start()
    {
        st = this.gameObject.transform.GetChild(0);
        at = this.gameObject.transform.GetChild(1);
        ht = this.gameObject.transform.GetChild(2);
        sAmount = this.gameObject.transform.GetChild(3).GetComponent<Text>();
        aAmount = this.gameObject.transform.GetChild(4).GetComponent<Text>();
        hAmount = this.gameObject.transform.GetChild(5).GetComponent<Text>();
    }

    public void updateStats(float shield, float armor, float hull)
    {
        shieldMax = shield;
        armorMax = armor;
        hullMax = hull;

        shieldCur = shieldMax;
        armorCur = armorMax;
        hullCur = hullMax;

        sAmount.text = shieldCur.ToString();
        aAmount.text = armorCur.ToString();
        hAmount.text = hullCur.ToString();

        RectTransform rt = st.GetComponent<RectTransform>();
        sWidth = rt.sizeDelta.x;
        rt = st.GetComponent<RectTransform>();
        aWidth = rt.sizeDelta.x;
        rt = st.GetComponent<RectTransform>();
        hWidth = rt.sizeDelta.x;
    }

    public void takeDamage(float amount)
    {
        updateShields(amount);
    }

    private void updateShields(float amount)
    {
        if (shieldCur - amount >= 0) 
        {
            shieldCur = shieldCur - amount;
        }
        else
        {
            shieldCur = 0;
            updateArmor((shieldCur - amount) *-1);
        }

        sAmount.text = shieldCur.ToString();
        float percent = (shieldCur / shieldMax);
        st.GetComponent<Image>().fillAmount = percent;
    }

    private void updateArmor(float amount)
    {
        if (armorCur - amount >= 0)
        {
            armorCur = armorCur - amount;
        }
        else
        {
            armorCur = 0;
            updateHull((armorCur - amount) * -1);
        }
        aAmount.text = armorCur.ToString();
        float percent = (armorCur / armorMax);
        at.GetComponent<Image>().fillAmount = percent;
    }

    private void updateHull(float amount)
    {
        if (hullCur - amount > 0)
        {
            hullCur = hullCur - amount;
        }
        else
        {
            hullCur = 0;
            Debug.Log("game over");
        }


        hAmount.text = hullCur.ToString();
        float percent = (hullCur / hullMax);
        ht.GetComponent<Image>().fillAmount = percent;
    }

    public void healShields(float amount)
    {
        if (amount > 0)
        {
            updateShields(-amount);
        }
    }

    public void healArmor(float amount)
    {
        if (amount > 0)
        {
            updateArmor(-amount);
        }
    }

    public void healHull(float amount)
    {
        if (amount > 0)
        {
            updateHull(-amount);
        }
    }
}

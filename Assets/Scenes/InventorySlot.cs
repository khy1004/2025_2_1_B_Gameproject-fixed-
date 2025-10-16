using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ItemData item;
    public int amount;

    [Header("UI Refernece")]
    public Image itemlcon;
    public Text amountText;
    public GameObject emptySlotImage;

    void Start()
    {
        UpdateSlotUI();
    }

    public void Setltem(ItemData newltem, int newAmount)
    {
        item = newltem;
        amount = newAmount;
        UpdateSlotUI();
    }
    public void AddAmount(int value)
    {
        amount += value;
        UpdateSlotUI();
    }

    public void RemoveAmount(int value)
    {
        amount -= value;

        if(amount <= 0 )
        {
            ClearSlot();
        }
        else
        {
            UpdateSlotUI();
        }
       
    }

    public void ClearSlot()
    {
        item = null;
        amount = 0;
        UpdateSlotUI();
    }


    // Start is called before the first frame update
    void UpdateSlotUI()
    {
        if (item != null)
        {
            itemlcon.sprite = item.itemlcon;
            itemlcon.enabled = true;

            amountText.text = amount > 1 ? amount.ToString() : "";
            if (emptySlotImage != null)
            {
                emptySlotImage.SetActive(false);
            }
        }
        else
        {
            itemlcon.enabled = false;
            amountText.text = "";

            if(emptySlotImage != null)
            {
                emptySlotImage.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    
}

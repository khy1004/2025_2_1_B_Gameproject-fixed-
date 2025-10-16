using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [Header("Inventroy Setting")]
    public int inventorySize = 20;
    public GameObject inventoryUI;
    public Transform itemSlotParent;
    public GameObject itemSletPrefab;

    [Header("Input")]
    public KeyCode inventoryKey = KeyCode.I;
    public List<InventorySlot> slots = new List<InventorySlot>();
    private bool isInventoryOpen = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        CreatelnventorySlots();
        inventoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(inventoryKey))
        {
            Togglelnventory();
        }
    }

    void CreatelnventorySlots()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            GameObject slotObject = Instantiate(itemSletPrefab, itemSlotParent);
            InventorySlot slot = slotObject.GetComponent<InventorySlot>();
            slots.Add(slot);
        }
    }
    public void Togglelnventory()
    {
        isInventoryOpen = !isInventoryOpen;
        inventoryUI.SetActive(isInventoryOpen);

        if (isInventoryOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = this;

        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }

    }

    public bool Addltem(ItemData item, int amount = 1)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == item && slot.amount < item.maxStack)
            {
                int spaceeLeft = item.maxStack - slot.amount;
                int amountToAdd = Mathf.Min(amount, spaceeLeft);
                slot.AddAmount(amountToAdd);

                amount -= amountToAdd;

                if(amount <= 0)
                {
                    return true;
                }
            }
        }

        foreach(InventorySlot slot in slots)
        {
            if (slot.item == null)
            {
                slot.Setltem(item, amount);
                return true;
            }
        }
        Debug.Log("인벤토리가 가득 참");
        return false;
    }

    public void Removeltem(ItemData item, int amount = 1)
    {
        foreach(InventorySlot slot in slots)
        {
            if(slot.item == item)
            {
                slot.RemoveAmount(amount);
                return;
            }
        }
    }

    public int GetltemCount(ItemData item)
    {
        int count = 0;
        foreach (InventorySlot slot in slots)
        {
            if (slot.item == item)
            {
                count += slot.amount;
            }
        }
        return count;
    }


}

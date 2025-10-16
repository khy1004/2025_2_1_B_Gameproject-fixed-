using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpltem : InteractableObject
{
    public ItemData itemData;
    public int amount = 1;

    public override void Interact()
    {
        base.Interact();

        if(InventoryManager.Instance != null)
        {
            bool added = InventoryManager.Instance.Addltem(itemData, amount);

            if (added)
            {
                Destroy(gameObject);
            }
        }
    }
    // Start is called before the first frame update
    
    // Update is called once per frame
    
}

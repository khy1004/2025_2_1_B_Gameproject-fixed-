using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ltem" , menuName = "lnventory/ltem")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite itemlcon;
    public int maxStack = 99;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

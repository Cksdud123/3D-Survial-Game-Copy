using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Net Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public string itemName;
    [TextArea]
    public string itemDesc;
    public ItemType itemType;
    public Sprite itemImage;
    public GameObject itemPrefab;

    public string weaponType;

    public enum ItemType
    {
        Equipment,
        Used,
        Ingredient,
        ECT
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

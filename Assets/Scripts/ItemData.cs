using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
    Consumable
}

[CreateAssetMenu(fileName = "NewItem", menuName = "Item/Create New Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public int attackBonus;
    public int defenseBonus;
}

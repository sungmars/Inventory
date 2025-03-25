public class Item
{
    public string Name { get; private set; }
    public ItemType Type { get; private set; }
    public int AttackBonus { get; private set; }
    public int DefenseBonus { get; private set; }

    public Item(ItemData data)
    {
        Name = data.itemName;
        Type = data.itemType;
        AttackBonus = data.attackBonus;
        DefenseBonus = data.defenseBonus;
    }
}


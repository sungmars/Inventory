public enum ItemType
{
    Weapon,
    Armor,
    Consumable
}

public class Item
{
    public string Name { get; private set; }
    public ItemType Type { get; private set; }
    public int AttackBonus { get; private set; }
    public int DefenseBonus { get; private set; }

    public Item(string name, ItemType type, int attackBonus = 0, int defenseBonus = 0)
    {
        Name = name;
        Type = type;
        AttackBonus = attackBonus;
        DefenseBonus = defenseBonus;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int AttackPower { get; private set; }
    public int Defense { get; private set; }
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public float CriticalChance { get; private set; }
    public int Experience { get; private set; }
    public int Gold { get; private set; }
    public List<Item> Inventory { get; private set; } = new List<Item>();

    private Item equippedWeapon;
    private Item equippedArmor;
    public Character(string name, int level, int attackPower, int defense, int maxHealth, float criticalChance, int gold)
    {
        Name = name;
        Level = level;
        AttackPower = attackPower;
        Defense = defense;
        MaxHealth = maxHealth;
        Health = maxHealth;
        CriticalChance = Mathf.Clamp01(criticalChance);
        Experience = 0;
        Gold = gold;
    }
    public void AddItem(Item item)
    {
        Inventory.Add(item);
    }
    public void Equip(Item item)
    {
        if (!Inventory.Contains(item)) return;

        switch (item.Type)
        {
            case ItemType.Weapon:
                if (equippedWeapon != null)
                {
                    UnEquip(equippedWeapon);
                }
                AttackPower += item.AttackBonus;
                equippedWeapon = item;
                break;

            case ItemType.Armor:
                if (equippedArmor != null)
                {
                    UnEquip(equippedArmor);
                }
                Defense += item.DefenseBonus;
                equippedArmor = item;
                break;
        }
    }

    public void UnEquip(Item item)
    {
        if (item == equippedWeapon)
        {
            AttackPower -= item.AttackBonus;
            equippedWeapon = null;
        }
        else if (item == equippedArmor)
        {
            Defense -= item.DefenseBonus;
            equippedArmor = null;
        }
    }
    public bool IsEquipped(Item item)
    {
        return item == equippedWeapon || item == equippedArmor;
    }
    public void AddGold(int amount)
    {
        Gold += amount;
    }

    public bool SpendGold(int amount)
    {
        if (Gold >= amount)
        {
            Gold -= amount;
            return true;
        }
        return false;
    }
}

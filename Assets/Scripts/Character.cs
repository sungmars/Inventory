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

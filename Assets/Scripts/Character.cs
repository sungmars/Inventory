using UnityEngine;

public class Character
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int AttackPower { get; private set; }
    public int Defense { get; private set; }
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public float CriticalChance { get; private set; } // 0~1 사이의 값 (예: 0.2 → 20% 확률)
    public int Experience { get; private set; }
    public int Gold { get; private set; }


    public int maxExp;
    public Character(string name, int level, int attackPower, int defense, int maxHealth, float criticalChance)
    {
        Name = name;
        Level = level;
        AttackPower = attackPower;
        Defense = defense;
        MaxHealth = maxHealth;
        Health = maxHealth;
        CriticalChance = Mathf.Clamp01(criticalChance); 
        Experience = 0;
        Gold = 20000;
    }

    public void TakeDamage(int damage)
    {
        int reducedDamage = Mathf.Max(1, damage - Defense); // 최소 1의 피해는 받도록 설정
        Health = Mathf.Max(0, Health - reducedDamage);
    }

    public int Attack()
    {
        bool isCritical = Random.value < CriticalChance;
        int damage = isCritical ? AttackPower * 2 : AttackPower;
        return damage;
    }

    public void GainExperience(int amount)
    {
        Experience += amount;
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        int requiredExp = Level * 100; // 레벨업 경험치 요구량 
        maxExp = requiredExp;
        if (Experience >= requiredExp)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Experience -= Level * 100;
        Level++;
        AttackPower += 5;
        Defense += 2;
        MaxHealth += 10;
        Health = MaxHealth; // 레벨업 시 체력 회복
        CriticalChance = Mathf.Clamp01(CriticalChance + 0.01f); // 치명타 확률 증가 (최대 100%)
    }
    public void GainGold(int amount)
    {
        Gold += amount;
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private TMP_Text attackText;
    [SerializeField] private TMP_Text defenseText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text critChanceText;
    [SerializeField] private TMP_Text goldText;
    [SerializeField] private TMP_Text weaponText;
    [SerializeField] private TMP_Text armorText;

    private Character character;

    public void SetCharacter(Character character)
    {
        this.character = character;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (character != null)
        {

            healthText.text = $"{character.Health}/{character.MaxHealth}";
            attackText.text = $"{character.AttackPower}";
            defenseText.text = $"{character.Defense}";
            critChanceText.text = $"{character.CriticalChance * 100f:0.0}%";
            goldText.text = $"{character.Gold}";

            weaponText.text = character.EquippedWeapon != null
                ? $"무기: {character.EquippedWeapon.Name} (+{character.EquippedWeapon.AttackBonus})"
                : "무기: 없음";

            armorText.text = character.EquippedArmor != null
                ? $"방어구: {character.EquippedArmor.Name} (+{character.EquippedArmor.DefenseBonus})"
                : "방어구: 없음";
        }
    }

}

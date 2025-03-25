using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private TMP_Text attackText;
    [SerializeField] private TMP_Text defenseText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text critChanceText;
    [SerializeField] private Text goldText;

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

            healthText.text = $"체력: {character.Health}/{character.MaxHealth}";
            attackText.text = $"공격력: {character.AttackPower}";
            defenseText.text = $"방어력: {character.Defense}";
            critChanceText.text = $"치명타 확률: {character.CriticalChance * 100f:0.0}%";
            goldText.text = $"골드: {character.Gold} G";

        }
    }
}

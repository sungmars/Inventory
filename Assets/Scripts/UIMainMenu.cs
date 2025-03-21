using TMPro;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text characterNameText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text experienceText;
    [SerializeField] private TMP_Text goldText;
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
            characterNameText.text = character.Name;
            levelText.text = $"{character.Level}";
            experienceText.text = $"{character.Experience}/{character.maxExp}";
            goldText.text = $"{character.Gold}";
        }
    }
    public void OnStartGame()
    {
        UIManager uiManager = FindObjectOfType<UIManager>();
        uiManager.ShowStatus();
    }

    public void OnOpenInventory()
    {
        UIManager uiManager = FindObjectOfType<UIManager>();
        uiManager.ShowInventory();
    }
}

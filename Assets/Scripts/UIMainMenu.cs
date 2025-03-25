using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;
    [SerializeField] private TMP_Text playerInfoText;
    private void Start()
    {
        // 버튼 클릭 시 UIManager를 통해 해당 UI 열기
        statusButton.onClick.AddListener(OnClickStatus);
        inventoryButton.onClick.AddListener(OnClickInventory);
    }

    private void OnClickStatus()
    {
        UIManager.Instance.ShowStatus();
    }

    private void OnClickInventory()
    {
        UIManager.Instance.ShowInventory();
    }

    public void OpenMainMenu()
    {
        UIManager.Instance.ShowMainMenu();
    }
    public void SetCharacter(Character character)
    {
        playerInfoText.text = $"{character.Name} (Lv. {character.Level}) - 골드: {character.Gold} G";
    }
}

using UnityEngine;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Character Player { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        SetData();
        UIManager.Instance.ShowMainMenu();
    }

    private void SetData()
    {
        Player = new Character("Chad", 1, 10, 5, 100, 0.15f, 500);

        // 아이템 생성
        var sword = new Item("브론즈 소드", ItemType.Weapon, attackBonus: 5);
        var shield = new Item("나무 방패", ItemType.Armor, defenseBonus: 3);

        // 아이템 등록
        Player.AddItem(sword);
        Player.AddItem(shield);

        // 장착
        Player.Equip(sword);
        Player.Equip(shield);

        // UI에 전달
        UIManager.Instance.UIMainMenu.SetCharacter(Player);
        UIManager.Instance.UIStatus.SetCharacter(Player);
        UIManager.Instance.UIInventory.InitInventoryUI(Player.Inventory, Player);
    }

}

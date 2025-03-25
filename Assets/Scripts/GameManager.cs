using UnityEngine;

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

        var sword = new Item("브론즈 소드", ItemType.Weapon, attackBonus: 5);
        var shield = new Item("나무 방패", ItemType.Armor, defenseBonus: 3);

        Player.AddItem(sword);
        Player.AddItem(shield);

        Player.Equip(sword);
        Player.Equip(shield);

        UIManager.Instance.UIMainMenu.SetCharacter(Player);
        UIManager.Instance.UIStatus.SetCharacter(Player);
        UIManager.Instance.UIInventory.InitInventoryUI(Player.Inventory, Player);
    }

}

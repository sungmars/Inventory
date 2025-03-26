using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("ScriptableObject 아이템 데이터")]
    [SerializeField] private List<ItemData> itemDataList = new List<ItemData>();

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

        foreach (ItemData data in itemDataList)
        {
            var item = new Item(data);
            Player.AddItem(item);

            // 자동 장착 예시 (무기 1개, 방어구 1개만)
            if (item.Type == ItemType.Weapon && Player.EquippedWeapon == null)
                Player.Equip(item);
            else if (item.Type == ItemType.Armor && Player.EquippedArmor == null)
                Player.Equip(item);
        }

        UIManager.Instance.UIMainMenu.SetCharacter(Player);
        UIManager.Instance.UIStatus.SetCharacter(Player);
        UIManager.Instance.UIInventory.InitInventoryUI(Player.Inventory, Player);
    }
}

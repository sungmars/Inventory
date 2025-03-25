using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private Image backgroundImage;

    private Item item;
    private Character character;
    private UIInventory inventory;

    public void SetItem(Item item, Character character, UIInventory inventory)
    {
        this.item = item;
        this.character = character;
        this.inventory = inventory;
        RefreshUI();
    }

    public void OnClickSlot()
    {
        if (character.IsEquipped(item))
        {
            character.UnEquip(item);
        }
        else
        {
            character.Equip(item);
        }

        inventory.RefreshAllSlots(); // 모든 슬롯 다시 그림
    }

    public void RefreshUI()
    {
        itemNameText.text = item.Name;

        bool equipped = character.IsEquipped(item);

        // 색상 변경으로 장착 여부 표현
        backgroundImage.color = equipped ? Color.green : Color.white;
    }
}

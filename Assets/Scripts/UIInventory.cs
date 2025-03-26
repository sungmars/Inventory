using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;

    private List<UISlot> slotList = new List<UISlot>();
    private Character character;

    public void InitInventoryUI(List<Item> items, Character character)
    {
        this.character = character;

        // 슬롯 초기화
        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject);
        }
        slotList.Clear();

        foreach (Item item in items)
        {
            GameObject go = Instantiate(slotPrefab, slotParent);
            UISlot slot = go.GetComponent<UISlot>();
            slot.SetItem(item, character, this);

            // 클릭 이벤트 추가
            Button btn = go.GetComponent<Button>();
            if (btn != null)
                btn.onClick.AddListener(slot.OnClickSlot);

            slotList.Add(slot);
        }
    }

    public void RefreshAllSlots()
    {
        foreach (var slot in slotList)
        {
            slot.RefreshUI();
        }
    }
}

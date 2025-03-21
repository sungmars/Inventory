using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIMainMenu uiMainMenu;
    [SerializeField] private UIStatus uiStatus;
    [SerializeField] private UIInventory uiInventory;

    private void Start()
    {
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        uiStatus.gameObject.SetActive(false);
        uiInventory.gameObject.SetActive(false);
    }

    public void ShowStatus()
    {
        uiStatus.gameObject.SetActive(true);
        uiInventory.gameObject.SetActive(false);
    }

    public void ShowInventory()
    {
        uiStatus.gameObject.SetActive(false);
        uiInventory.gameObject.SetActive(true);
    }
}

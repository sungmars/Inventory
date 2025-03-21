using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public void OpenInventory()
    {
        gameObject.SetActive(true);
    }

    public void CloseInventory()
    {
        gameObject.SetActive(false);
    }
}

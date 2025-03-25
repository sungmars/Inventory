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
        // 임시 플레이어 데이터 생성
        Player = new Character("Chad", 1, 10, 5, 100, 0.15f, 500);

        // UI에 캐릭터 정보 전달
        UIManager.Instance.UIMainMenu.SetCharacter(Player);
        UIManager.Instance.UIStatus.SetCharacter(Player);
    }
}

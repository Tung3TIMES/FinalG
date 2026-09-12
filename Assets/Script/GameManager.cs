using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI / Panels")]
    public GameObject gameOverPanel;

    [Header("Ball Elements")]
    [SerializeField] private GameObject lineObject; // ลาก GameObject "Line" มาใส่ตรงนี้

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method ควบคุมการเปิด/ปิด Line
    public void SetLineActive(bool isActive)
    {
        if (lineObject != null)
        {
            lineObject.SetActive(isActive);
        }
    }

    public void GameOver(GameObject ball)
    {
        if (ball != null)
        {
            Destroy(ball);
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0f;
        Debug.Log("ลูกกอล์ฟลงหลุมแล้ว! จบเกม (Game Over)");
    }


}

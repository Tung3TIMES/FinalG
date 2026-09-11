using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI / Panels")]
    public GameObject gameOverPanel; // (ทางเลือก) หน้าต่าง UI จบเกม

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

    public void GameOver()
    {
        // หยุดเวลาในเกม (ถ้าต้องการให้ทุกอย่างหยุดนิ่ง)
        Time.timeScale = 0f;

        // แสดง UI จบเกม (ถ้ามีเซ็ตไว้)
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
}

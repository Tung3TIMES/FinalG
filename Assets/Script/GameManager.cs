using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI / Panels")]
    public GameObject gameOverPanel; // หน้าต่าง UI จบเกม

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

    // ปรับ Method ให้รับ GameObject ของลูกกอล์ฟเข้ามาเพื่อทำลายก่อนจบเกม
    public void GameOver(GameObject ball)
    {
        // 1. ทำลายลูกกอล์ฟทันทีเมื่อลงหลุม
        if (ball != null)
        {
            Destroy(ball);
        }

        // 2. แสดง UI จบเกม (ถ้ามีเซ็ตไว้)
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // 3. หยุดเวลาในเกม
        Time.timeScale = 0f;

        Debug.Log("ลูกกอล์ฟลงหลุมแล้ว! จบเกม (Game Over)");
    }


}

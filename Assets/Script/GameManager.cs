using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game Statistics")]
    public int totalScore = 0;
    public int strokesCount = 0; // จำนวนครั้งที่ตี

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ฟังก์ชันเพิ่มคะแนนเมื่อลงหลุม
    const int HoleInBonus = 100;
    public void AddHoleScore()
    {
        totalScore += HoleInBonus;
        Debug.Log($"ลูกกอล์ฟลงหลุมแล้ว! คะแนนรวมปัจจุบัน: {totalScore}");
    }

    // ฟังก์ชันนับจำนวนครั้งที่ตี (Stroke)
    public void AddStroke()
    {
        strokesCount++;
    }
}

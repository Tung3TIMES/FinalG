using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่าสิ่งที่ตกลงมาคือลูกกอล์ฟ (เช็คจาก Tag "GolfBall")
        if (other.CompareTag("GolfBall"))
        {
            Debug.Log("ลูกกอล์ฟลงหลุมแล้ว! จบเกมทันที");

            // เรียกฟังก์ชันจบเกม
            GameManager.Instance.GameOver();
        }
    }
}

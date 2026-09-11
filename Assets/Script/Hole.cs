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

            // ส่ง GameObject ของลูกกอล์ฟ (other.gameObject) ไปให้ GameManager ทำลายและสั่งจบเกม
            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameOver(other.gameObject);
            }
        }
    }
}

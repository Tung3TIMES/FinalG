using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่าวัตถุที่ตกลงไปคือลูกกอล์ฟหรือไม่ (โดยเช็คจาก Tag)
        if (other.CompareTag("GolfBall"))
        {
            // เรียกใช้งานระบบจัดการคะแนน
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddHoleScore();
            }

            // ตัวอย่างเพิ่มเติม: ซ่อนลูกกอล์ฟหรือเล่นเสียงเอฟเฟกต์
            HandleBallInHole(other.gameObject);
        }
    }

    private void HandleBallInHole(GameObject ball)
    {
        // ตัวอย่างการหยุดการเคลื่อนที่ของลูกกอล์ฟ
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            ball.SetActive(false); // ซ่อนลูกกอล์ฟ
        }

        // สามารถเพิ่มการเรียกใช้งาน UI ชนะเกม หรือเปลี่ยนฉาก (Scene) ตรงนี้ได้
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GolfBall : MonoBehaviour
{
    
    private Rigidbody rb;

    [Header("Shot Settings")]
    public float powerMultiplier = 15f; // ตัวคูณความแรงในการยิง
    public Vector3 defaultShootDirection = Vector3.forward; // ทิศทางการยิงเริ่มต้น (สามารถปรับเปลี่ยนได้ตามต้องการ)

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 1. กดปุ่ม Enter เพื่อยิงลูกกอล์ฟ (ตรวจสอบว่าลูกต้องหยุดนิ่งก่อนถึงจะยิงได้)
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (rb.linearVelocity.magnitude < 0.1f)
            {
                ShootBall(defaultShootDirection);
            }
        }

        // 2. กดปุ่ม Spacebar เพื่อหยุดลูกกอล์ฟทันทีในตำแหน่งปัจจุบัน
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopBall();
        }
    }

    // ฟังก์ชันสำหรับทำการยิงลูกกอล์ฟ
    public void ShootBall(Vector3 direction)
    {
        // เพิ่มแรงกระแทกตามทิศทางและตัวคูณความแรง
        rb.AddForce(direction.normalized * powerMultiplier, ForceMode.Impulse);

        // แจ้งเตือนไปยัง ScoreManager ว่ามีการตีเกิดขึ้น
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddStroke();
        }

        Debug.Log("ยิงลูกกอล์ฟแล้ว!");
    }

    // ฟังก์ชันหยุดลูกกอล์ฟในตำแหน่งล่าสุด
    public void StopBall()
    {
        // ล้างความเร็วทั้งหมดเป็นศูนย์ทันที
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // ทำให้ Rigidbody หยุดการคำนวณชั่วคราวเพื่อให้ลูกนิ่งสนิท
        rb.Sleep();

        Debug.Log($"ลูกกอล์ฟถูกหยุดในตำแหน่งล่าสุด: {transform.position}");
    }
}

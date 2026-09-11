using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GolfBall : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int forcePower = 500;
    [SerializeField] private float turnSpeed = 100f;

    // ตัวแปรสำหรับเก็บมุมเริ่มต้นของลูกกอล์ฟ
    private Quaternion initialRotation;

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        // บันทึกมุมเริ่มต้นเมื่อเริ่มเกมไว้ใช้รีเซ็ต
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        if (Keyboard.current == null) return;

        // 1. กด Enter เพื่อยิง
        bool enterPressed = Keyboard.current.enterKey.wasPressedThisFrame ||
                             Keyboard.current.numpadEnterKey.wasPressedThisFrame;

        if (enterPressed)
        {
            if (rb.linearVelocity.magnitude < 50f)
            {
                ShootBall();
            }
        }

        // 2. กด Spacebar เพื่อหยุดลูกกอล์ฟ และรีเซ็ตทิศทางหน้าลูกกอล์ฟ
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            StopBall();
        }

        // 3. หันซ้าย-ขวาด้วย A / D
        if (Keyboard.current.aKey.isPressed)
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }

        if (Keyboard.current.dKey.isPressed)
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
    }

    private void ShootBall()
    {
        rb.AddForce(transform.forward * forcePower, ForceMode.Impulse);
        Debug.Log("ยิงลูกกอล์ฟไปข้างหน้าด้วยแรง: " + forcePower);
    }

    private void StopBall()
    {
        // 1. หยุดความเร็วการเคลื่อนที่และการหมุนของ Rigidbody
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // 2. รีเซ็ตมุมหมุนของลูกกอล์ฟกลับไปเป็นค่าเริ่มต้น
        transform.rotation = initialRotation;

        Debug.Log("หยุดลูกกอล์ฟและรีเซ็ตหน้าลูกกอล์ฟกลับเป็นค่าเดิมเรียบร้อยแล้ว");
    }

    private void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่าวัตถุที่ชนมี Tag ชื่อ "Hole" หรือไม่
        if (other.CompareTag("Hole"))
        {
            if (GameManager.Instance != null)
            {
                // ส่ง GameObject ลูกกอล์ฟตัวนี้ไปให้ GameManager ทำลายและสั่ง GameOver
                GameManager.Instance.GameOver(gameObject);
            }
        }
    }

}

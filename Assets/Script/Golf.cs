using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GolfBall : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int forcePower = 500;
    [SerializeField] private float turnSpeed = 100f;

    private Quaternion initialRotation;

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        initialRotation = transform.rotation;
    }

    private void Update()
    {
        if (Keyboard.current == null) return;

        // 1. กด Enter หรือ Numpad Enter เพื่อยิง
        bool enterPressed = Keyboard.current.enterKey.wasPressedThisFrame ||
                             Keyboard.current.numpadEnterKey.wasPressedThisFrame;

        if (enterPressed)
        {
            if (rb.linearVelocity.magnitude < 50f)
            {
                ShootBall();
            }
        }

        // 2. กด Spacebar เพื่อหยุดลูกกอล์ฟ
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            StopBall();
        }

        // 3. หมุนซ้าย-ขวา ด้วยปุ่ม A/D
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

        // ซ่อน Line เมื่อยิงลูกกอล์ฟออกไป
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SetLineActive(false);
        }

        Debug.Log("ยิงลูกกอล์ฟไปข้างหน้าด้วยแรง: " + forcePower);
    }

    private void StopBall()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.rotation = initialRotation;

        // แสดง Line อีกครั้งเมื่อกดหยุดลูกกอล์ฟ
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SetLineActive(true);
        }

        Debug.Log("หยุดลูกกอล์ฟและรีเซ็ตตำแหน่ง/แสดง Line เรียบร้อยแล้ว");
    }

}

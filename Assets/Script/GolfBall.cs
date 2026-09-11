using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GolfBall : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int forcePower;

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    private void Update()
    {
        // ตรวจสอบว่ามีคีย์บอร์ดเชื่อมต่ออยู่หรือไม่
        if (Keyboard.current == null) return;

        // 2. เช็กการกดปุ่ม Enter หรือ Numpad Enter ด้วย New Input System
        bool enterPressed = Keyboard.current.enterKey.wasPressedThisFrame ||
                             Keyboard.current.numpadEnterKey.wasPressedThisFrame;

        if (enterPressed)
        {
            if (rb.linearVelocity.magnitude < 50f)
            {
                ShootBall();
            }
        }
    }

    private void ShootBall()
    {
        rb.AddForce(Vector3.forward * forcePower, ForceMode.Impulse);
        Debug.Log("ยิงลูกกอล์ฟไปข้างหน้าด้วยแรง: " + forcePower);
    }



}

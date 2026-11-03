using UnityEngine;
using UnityEngine.InputSystem; // Обязательно добавить для Gamepad

public class PlayerMovement : MonoBehaviour
{
    [Header("Настройки движения")]
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Ввод с клавиатуры 
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 keyboardInput = new Vector2(x, y);

        //Ввод с виртуального джойстика
        Vector2 joystickInput = Vector2.zero;
        if (Gamepad.current != null)
        {
            joystickInput = Gamepad.current.leftStick.ReadValue();
        }

        // 3. Суммируем оба ввода и нормализуем
        moveInput = (keyboardInput + joystickInput).normalized;
    }

    private void FixedUpdate()
    {
        // Движение через физику
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}
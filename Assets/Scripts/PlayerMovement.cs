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

        //Ввод с гироскопа (только на мобильных устройствах)
        Vector2 gyroInput = Vector2.zero;
        if (Application.isMobilePlatform && SystemInfo.supportsGyroscope)
        {
            // Читаем направление из нашего скрипта GyroInput
            gyroInput = GyroInput.GyroDirection;
        }

        // 4. Суммируем все вводы и нормализуем
        moveInput = (keyboardInput + joystickInput + gyroInput).normalized;
    }

    private void FixedUpdate()
    {
        // Движение через физику
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}
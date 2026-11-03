using UnityEngine;

public class GyroInput : MonoBehaviour
{
    // Статическая переменная, чтобы другие скрипты могли читать направление
    public static Vector2 GyroDirection { get; private set; }

    private bool gyroEnabled;

    private void Start()
    {
        // Проверяем, поддерживает ли устройство гироскоп
        if (SystemInfo.supportsGyroscope)
        {
            // Включаем гироскоп (обязательно)
            Input.gyro.enabled = true;
            gyroEnabled = true;
            Debug.Log("Гироскоп включен.");
        }
        else
        {
            Debug.Log("Гироскоп не поддерживается на этом устройстве.");
        }
    }

    private void Update()
    {
        if (!gyroEnabled) return;

        // Получаем вектор гравитации в системе координат устройства
        Vector3 gravity = Input.gyro.gravity;

        // В портретном режиме:
        // gravity.x — наклон влево/вправо
        // gravity.y — наклон вперед/назад (вверх/вниз)
        // Мы используем X и Y для движения по 2D-осям.
        GyroDirection = new Vector2(gravity.x, gravity.y);
    }
}
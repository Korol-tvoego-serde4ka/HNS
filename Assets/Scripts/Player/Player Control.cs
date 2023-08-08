using UnityEngine;

public class FirstPersonController : MonoBehaviour
{

    public float speed = 10f;

    public Joystick joystick;

    public Rigidbody rb;
    public Transform cameraTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Получаем направление камеры
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Используем джойстик для управления 
        float vertical = joystick.Vertical;
        float horizontal = joystick.Horizontal;

        // Считаем нужное направление движения
        Vector3 direction = vertical * forward + horizontal * right;

        // Двигаем персонажа
        rb.velocity = direction * speed;

        // Ограничение скорости
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed);

        // Поворачиваем персонажа в направлении движения
        //transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

}
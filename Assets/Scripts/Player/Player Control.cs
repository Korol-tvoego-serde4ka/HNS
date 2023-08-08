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
        // �������� ����������� ������
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // ���������� �������� ��� ���������� 
        float vertical = joystick.Vertical;
        float horizontal = joystick.Horizontal;

        // ������� ������ ����������� ��������
        Vector3 direction = vertical * forward + horizontal * right;

        // ������� ���������
        rb.velocity = direction * speed;

        // ����������� ��������
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed);

        // ������������ ��������� � ����������� ��������
        //transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

}
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Joystick moveJoystick;
    public Joystick lookJoystick;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public Button jumpButton;
    public Button crouchButton;

    public Camera mainCamera;
    public float cameraRotationSpeed = 1f;

    private CharacterController controller;
    private Vector3 moveDirection;

    public float playerRotationSpeed = 5f;

    void Start()
    {

        controller = GetComponent<CharacterController>();

        jumpButton.onClick.AddListener(() => {
            Jump();
        });

    }

    void Update()
    {

        // Движение
        moveDirection = new Vector3(moveJoystick.Horizontal, 0, moveJoystick.Vertical);
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

    }

    void Jump()
    {

        if (controller.isGrounded)
        {
            Vector3 jumpVelocity = Vector3.up * jumpForce * moveSpeed;
            controller.Move(jumpVelocity * Time.deltaTime);
        }

    }

    void LateUpdate()
    {

        float cameraAngle = lookJoystick.Horizontal * cameraRotationSpeed;

        // Поворот камеры на cameraAngle

        float playerAngle = lookJoystick.Horizontal * playerRotationSpeed;

        // Поворот игрока на playerAngle
        transform.Rotate(0, playerAngle, 0);
    }

}
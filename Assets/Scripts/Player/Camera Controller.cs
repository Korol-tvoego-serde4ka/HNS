using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform character;
    public float sensitivity = 2f;
    public Joystick joystick;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - character.position;
    }

    
    void LateUpdate()
    {

        float horizontal = joystick.Horizontal;

        float desiredAngle = character.eulerAngles.y + horizontal;

        Quaternion rotation = Quaternion.AngleAxis(desiredAngle, Vector3.up);

        transform.rotation = rotation;

        character.eulerAngles = new Vector3(0, desiredAngle, 0);
    }
}
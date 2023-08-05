using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Debug;

public class PlayerScript : MonoBehaviour
{
    void Start()
    {
        Log("Test");
    }
    public Joystick joystick;

    [Header("�������� ����������� ���������")]
    public float speed = 7f;

    [Header("�������� ���� ���������")]
    public float runSpeed = 7f;

    [Header("���� ������")]
    public float jumpPower = 200f;

    [Header("�� �� �����?")]
    public bool ground;

    public Button jumpButton;

    private float vertical;
    private float horizontal;

    private void Update()
    {
        GetMobileInput();
    }

    private void GetMobileInput()
    {
        vertical = joystick.Vertical;
        horizontal = joystick.Horizontal;

        if (vertical >= 0.5f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += transform.forward * runSpeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += transform.forward * speed * Time.deltaTime;
            }
        }

        if (vertical <= -0.5f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += -transform.forward * runSpeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += -transform.forward * speed * Time.deltaTime;
            }
        }

        if (horizontal <= -0.5f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += -transform.right * runSpeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += -transform.right * speed * Time.deltaTime;
            }
        }

        if (horizontal >= 0.5f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += transform.right * runSpeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += transform.right * speed * Time.deltaTime;
            }
        }
        if (Input.GetButtonDown("Jump"))
        {
            Log(ground);

            Log(new StackTrace().ToString());

            if (ground)
            {
                Log("Jumping...");

                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = false;
        }
    }
}
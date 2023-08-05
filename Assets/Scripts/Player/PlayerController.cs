using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Joystick joystick;

    [Header("Скорость перемещения персонажа")]
    public float speed = 7f;

    [Header("Скорость бега персонажа")]
    public float runSpeed = 7f;

    [Header("Сила прыжка")]
    public float jumpPower = 200f;

    [Header("Мы на земле?")]
    public bool ground;

    public Rigidbody rb;
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
        if (Input.GetButtonDown("Jump") && ground)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            ground = false;
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
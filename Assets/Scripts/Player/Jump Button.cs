using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour
{

    public float jumpForce = 10f;

    public Rigidbody rb;

    public Button jumpButton;

    bool isGrounded = true;

    void Start()
    {
        jumpButton.onClick.AddListener(Jump);
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

}
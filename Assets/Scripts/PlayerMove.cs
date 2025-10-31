using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField,Tooltip("ƒWƒƒƒ“ƒvˆÐ—Í")] private float jumpForce = 100f;
    [SerializeField, Tooltip("—Ž‰ºˆÐ—Í")] private float flowForce = 100f;

    private Rigidbody2D rb;

    /// <summary> ’…’n”»’è </summary>
    private bool isGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGround = false;
        }

        if (!isGround && Input.GetKeyDown(KeyCode.LeftControl))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -flowForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}

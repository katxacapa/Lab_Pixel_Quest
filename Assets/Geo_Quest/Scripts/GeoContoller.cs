
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeoContoller : MonoBehaviour
{
    public int variable1 = 2;
    public float jumpForce = 7f;
    public float bounceForce = 12f;
    public string nextLevel = "Level2";

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Horizontal movement
        float xInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(
            xInput * variable1,
            rb2d.velocity.y
        );

        // Jump with Spacebar
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2d.velocity = new Vector2(
                rb2d.velocity.x,
                jumpForce
            );
            isGrounded = false;
        }

        // Switch colors with 1, 2, and 3
        if (Input.GetKeyDown(KeyCode.Alpha1))
            spriteRenderer.color = Color.red;

        if (Input.GetKeyDown(KeyCode.Alpha2))
            spriteRenderer.color = Color.green;

        if (Input.GetKeyDown(KeyCode.Alpha3))
            spriteRenderer.color = Color.blue;
    }

    // Detect landing on solid ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Detect spikes, bounce pads, and goals
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death"))
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().name
            );
        }
        else if (collision.CompareTag("BouncePad"))
        {
            rb2d.velocity = new Vector2(
                rb2d.velocity.x,
                bounceForce
            );
            isGrounded = false;
        }
        else if (collision.CompareTag("Finish"))
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}

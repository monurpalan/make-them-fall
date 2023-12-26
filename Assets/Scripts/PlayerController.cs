using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float[] posx;
    [SerializeField] private bool isHit;
    [SerializeField] private bool isRight;
    private bool isRotating = false;
    void Start()
    {

    }


    void Update()
    {
        Vector3 _mousePos = Camera.main.ScreenToWorldPoint(new Vector3(
            Input.mousePosition.x,
            transform.position.y,
            transform.position.z
        ));

        if (isRotating)
        {

            float step = 15f * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, isRight ? 0 : 180f, 0), step);


            if (Quaternion.Angle(transform.rotation, Quaternion.Euler(0, isRight ? 0 : 180f, 0)) < 0.1f)
            {
                isRotating = false;
            }
        }

        if (Input.GetMouseButtonDown(0) && isHit == true && _mousePos.x >= posx[0] && _mousePos.x <= posx[1])
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            Flip();
            isHit = false;
            if (!isHit)
            {
                moveSpeed *= -1;
            }
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            isHit = true;
        }
    }
    private void Flip()
    {
        isRight = !isRight;
        isRotating = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Score"))
        {
            gameManager.score++;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();
        }
    }
}
